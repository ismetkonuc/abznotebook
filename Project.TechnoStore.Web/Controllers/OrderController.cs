﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Entities.Concrete;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.TechnoStore.Web.Models;


namespace Project.TechnoStore.Web.Controllers
{
    public class OrderController : Controller
    {

        private readonly IAddressService _addressService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IShipperService _shipperService;
        private readonly IPaymentService _paymentService;
        private readonly Cart _cart;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;

        public OrderController(IAddressService addressService, UserManager<AppUser> userManager, IShipperService shipperService, IPaymentService paymentService, Cart cart, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _addressService = addressService;
            _userManager = userManager;
            _paymentService = paymentService;
            _shipperService = shipperService;
            _cart = cart;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var x = _cart.Lines;

            if (User.Identity.IsAuthenticated)
            {
                var appUser = await _userManager.GetUserAsync(User);
                ViewBag.Address = _addressService?.GetAddressesByUserId(appUser.Id);

                ViewBag.AddressCollection = new SelectList(ViewBag.Address, "Id", "Title");
                ViewBag.PaymentCollection = new SelectList(_paymentService.GetAllPayments(), "PaymentId", "PaymentType");
                ViewBag.ShipperCollection = new SelectList(_shipperService.GetAllShippers(), "Id", "CompanyName");
            }

            return View(new OrderViewModel());
        }

        public async Task<IActionResult> Checkout(OrderViewModel model)
        {
            var appUser = await _userManager.GetUserAsync(User);

            Guid orderNumber = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                _orderService.Save(new Order()
                {
                    PaymentId = model.PaymentId,
                    IsShipped = false,
                    CustomerId = appUser.Id,
                    OrderDate = DateTime.Now,
                    OrderNumber = orderNumber,
                    ShipperId = model.ShipperId,
                });

                foreach (var cartLine in _cart.Lines)
                {
                    _orderDetailService.Save(new OrderDetail()
                    {
                        ProductId = cartLine.Product.Id,
                        OrderId = _orderService.GetAllOrders().Single(I=>I.OrderNumber.Equals(orderNumber)).Id,
                        Price = cartLine.Product.UnitPrice,
                        Quantity = cartLine.Quantity,
                    });
                }

                int orderId = _orderService.GetAllOrders().Single(I => I.OrderNumber.Equals(orderNumber)).Id;

                return RedirectToAction("Completed", new{orderId = orderId});
            }

            return View(model);
        }

        public IActionResult Completed(int orderId)
        {
            return View(orderId);
        }



    }
}
