using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
        public IActionResult Delivery(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Payment", new {AddressId = model.AddressId, ShipperId = model.ShipperId});
            }

            ModelState.AddModelError("", "Bir şeyler ters gitti");
            model.OrderSummary = CreateSidebar();
            return View(model);
        }

        [HttpGet]
        public IActionResult Payment(int AddressId, int ShipperId)
        {

            List<int> Months = new List<int>() {1,2,3,4,5,6,7,8,9,10,11,12};

            List<int> Years = new List<int>() {2021, 2022, 2023, 2024, 2025, 2026, 2027,2028, 2029, 2030};

            PaymentViewModel model = new PaymentViewModel()
            {
                AddressId = AddressId,
                ShipperId = ShipperId,
                LinesCount = _cart.Lines.Count,
                MonthCollection = new SelectList(Months, "ExpiredMonth"),
                YearCollection = new SelectList(Years, "ExpiredYear")
            };

            model.OrderSummary = CreateSidebar();

            return View(model);
        }

        [HttpPost]
        public IActionResult Payment(PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Checkout");
            }
            ModelState.AddModelError("", "Bir şeyler ters gitti");

            model.OrderSummary = CreateSidebar();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            OrderViewModel model = new OrderViewModel()
            {
                LinesCount = _cart.Lines.Count
            };

            if (User.Identity.IsAuthenticated)
            {
                var appUser = await _userManager.GetUserAsync(User);

                model.Addresses = _addressService.GetAddressesByUserId(appUser.Id);
                model.AddressCollection = new SelectList(model.Addresses, "Id", "Title");
                model.PaymentCollection = new SelectList(_paymentService.GetAllPayments(), "PaymentId", "PaymentType");
                model.ShipperCollection = new SelectList(_shipperService.GetAllShippers(), "Id", "CompanyName");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderViewModel model)
        {
            var appUser = await _userManager.GetUserAsync(User);
            model.LinesCount = _cart.Lines.Count;
            model.Addresses = _addressService?.GetAddressesByUserId(appUser.Id);
            model.AddressCollection = new SelectList(model.Addresses, "Id", "Title");
            model.PaymentCollection = new SelectList(_paymentService.GetAllPayments(), "PaymentId", "PaymentType");
            model.ShipperCollection = new SelectList(_shipperService.GetAllShippers(), "Id", "CompanyName");

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
                    PaymentId = model.PaymentId,
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

                int orderId = _orderService.GetAllOrders().Single(I => I.OrderNumber.Equals(orderNumber)).Id;
                return RedirectToAction("Completed", new { orderId = orderId });
            }

            ModelState.AddModelError("", "Seç");

            return View(model);
        }

        public IActionResult Completed(int orderId)
        {
            return View(orderId);
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
                    ProductQuantity = cartLine.Quantity
                });
            }

            return sidebar;
        }

    }
}
