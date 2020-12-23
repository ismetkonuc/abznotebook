using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Entities.Concrete;
using Project.TechnoStore.Web.Areas.Member.Models;

namespace Project.TechnoStore.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles="Member")]
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IAddressService _addressService;
        private readonly IShipperService _shipperService;
        private readonly IProductService _productService;
        public OrderController(IOrderService orderService, UserManager<AppUser> userManager, IAppUserService appUserService, IOrderDetailService orderDetailService, IAddressService addressService, IShipperService shipperService, IProductService productService)
        {
            _orderService = orderService;
            _userManager = userManager;
            _appUserService = appUserService;
            _orderDetailService = orderDetailService;
            _addressService = addressService;
            _shipperService = shipperService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
