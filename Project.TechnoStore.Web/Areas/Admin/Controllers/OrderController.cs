using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.TechnoStore.Business.Concrete;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Entities.Concrete;
using Project.TechnoStore.Web.Areas.Admin.Models;

namespace Project.TechnoStore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {

        private readonly IOrderDetailService _orderDetailService;
        private readonly IShipperService _shipperService;
        private readonly IAddressService _addressService;
        private readonly IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IPaymentService _paymentService;
        private readonly IAppUserService _appUserService;
        private readonly IProductService _productService;
        public OrderController(IOrderDetailService orderDetailService, IShipperService shipperService, IAddressService addressService, IOrderService orderService, UserManager<AppUser> userManager, IPaymentService paymentService, IAppUserService appUserService, IProductService productService)
        {
            _orderDetailService = orderDetailService;
            _shipperService = shipperService;
            _addressService = addressService;
            _orderService = orderService;
            _userManager = userManager;
            _paymentService = paymentService;
            _appUserService = appUserService;
            _productService = productService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Detail(int orderId)
        {

            List<BillViewModel> bill = new List<BillViewModel>();

            Order order = _orderService.GetOrderWithId(orderId);


            OrderDetailViewModel model = new OrderDetailViewModel()
            {
                CustomerId = order.CustomerId,
                OrderId = order.Id,
                OrderDate = order.OrderDate,
                ShipDate = order.ShipDate,
                IsShipped = order.IsShipped,
                PaymentMethod = _paymentService.GetPaymentNameWithId(order.PaymentId),
                CustomerFullName = _appUserService.GetOrderOwnerFullNameWithUserId(order.CustomerId),
                AddressId = order.AddressId
            };

            model.OrderDetails = _orderDetailService.GetAllOrderDetails().Where(I => I.OrderId == orderId).ToList();
            model.Address = _addressService.GetAddressesByUserId(order.CustomerId)
                .Single(I => I.Id == order.AddressId);
            model.Shipper = _shipperService.GetAllShippers().Single(I => I.Id == order.ShipperId);

            foreach (var orderDetail in model.OrderDetails)
            {
                bill.Add(new BillViewModel()
                {
                    UnitPrice = orderDetail.Price,
                    OrderId = orderDetail.OrderId,
                    Quantity = orderDetail.Quantity,
                    Product = _productService.Products.Single(I=>I.Id == orderDetail.ProductId),
                    TotalPrice = _orderDetailService.ComputeTotalPriceOfOrder(model.OrderId)
                });
            }

            model.Bill = bill;

            return View(model);
        }

    }
}
