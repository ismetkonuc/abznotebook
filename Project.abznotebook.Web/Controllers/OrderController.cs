using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.abznotebook.Business.Interfaces;
using Project.abznotebook.Entities.Concrete;
using Project.abznotebook.Web.Models;


namespace Project.abznotebook.Web.Controllers
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
        public async Task<IActionResult> Delivery()
        {
            AppUser user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            OrderViewModel model = new OrderViewModel()
            {
                Addresses = _addressService.GetAddressesByUserId(user.Id),
                LinesCount = _cart.Lines.Count,
                ShipperCollection = new SelectList(_shipperService.GetAllShippers(), "Id", "CompanyName"),
                AddressCollection = new SelectList(_addressService.GetAddressesByUserId(user.Id), "Id", "Title")
            };

            model.OrderSummary = CreateSidebar();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delivery(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Payment", new {AddressId = model.AddressId, ShipperId = model.ShipperId});
            }

            AppUser user = await _userManager.GetUserAsync(User);
            model.OrderSummary = CreateSidebar();
            model.Addresses = _addressService.GetAddressesByUserId(user.Id);
            model.LinesCount = _cart.Lines.Count;
            model.ShipperCollection = new SelectList(_shipperService.GetAllShippers(), "Id", "CompanyName");
            model.AddressCollection = new SelectList(_addressService.GetAddressesByUserId(user.Id), "Id", "Title");

            return View(model);
        }

        [HttpGet]
        public IActionResult Payment(int AddressId, int ShipperId)
        {
            PaymentViewModel model = new PaymentViewModel()
            {
                AddressId = AddressId,
                ShipperId = ShipperId,
                LinesCount = _cart.Lines.Count
            };

            model.OrderSummary = CreateSidebar();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment(PaymentViewModel model)
        {
            var appUser = await _userManager.GetUserAsync(User);
            model.LinesCount = _cart.Lines.Count;
            if (model.LinesCount == 0)
            {
                ModelState.AddModelError("", "Sepetiniz boş!");
                return View(model);
            }

            Guid orderNumber = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                _orderService.Save(new Order()
                {
                    PaymentId = 1,
                    IsShipped = false,
                    CustomerId = appUser.Id,
                    OrderDate = DateTime.Now,
                    OrderNumber = orderNumber,
                    ShipperId = model.ShipperId,
                    AddressId = model.AddressId
                });

                foreach (var cartLine in _cart.Lines)
                {
                    _orderDetailService.Save(new OrderDetail()
                    {
                        ProductId = cartLine.Product.Id,
                        OrderId = _orderService.GetAllOrders().Single(I => I.OrderNumber.Equals(orderNumber)).Id,
                        Price = cartLine.Product.UnitPrice,
                        Quantity = cartLine.Quantity,
                    });
                }

                return RedirectToAction("Completed", new { orderNumber = orderNumber });
            }

            model.OrderSummary = CreateSidebar();

            return View(model);

            
            
        }

        [Authorize]
        public IActionResult Completed(Guid orderNumber)
        {
            int orderId = 0;

            try
            {
                orderId = _orderService.GetAllOrders().Single(I => I.OrderNumber.Equals(orderNumber)).Id;
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            OrderSummarySidebarViewModel model = CreateSidebar();
            model.OrderId = orderId;
            return View(model);
        }


        public OrderSummarySidebarViewModel CreateSidebar()
        {
            OrderSummarySidebarViewModel sidebar = new OrderSummarySidebarViewModel()
            {
                TotalPrice = _cart.ComputeTotalValue(),
                ProductSummaries = new List<ProductSummaryViewModel>()
            };

            foreach (var cartLine in _cart.Lines)
            {
                sidebar.ProductSummaries.Add(new ProductSummaryViewModel()
                {
                    ProductId = cartLine.Product.Id,
                    ProductName = cartLine.Product.Name,
                    ProductImg = cartLine.Product.Image1,
                    ProductPrice = cartLine.Product.UnitPrice,
                    ProductQuantity = cartLine.Quantity,
                    ProductDescription = cartLine.Product.Description,
                    ProductDiscountPrice = cartLine.Product.RealPrice
                });
            }

            return sidebar;
        }

    }
}
