using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Entities.Concrete;
using Project.TechnoStore.Web.Areas.Admin.Models;
using Project.TechnoStore.Web.Base.Common.Models;

namespace Project.TechnoStore.Web.Areas.Member.Components
{
    public class UserOrdersSummaryViewComponent : ViewComponent
    {

        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly IAppUserService _appUserService;
        private readonly UserManager<AppUser> _userManager;

        public UserOrdersSummaryViewComponent(IOrderService orderService, IPaymentService paymentService, IAppUserService appUserService, UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _paymentService = paymentService;
            _appUserService = appUserService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = GetAllOrderSummaries(appUser).OrderByDescending(I => I.OrderDate).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", model));
        }

        public List<OrderSummaryViewModel> GetAllOrderSummaries(AppUser appUser)
        {

            List<OrderSummaryViewModel> model = new List<OrderSummaryViewModel>();

            var orders = _orderService.GetAllOrders().Where(I=>I.CustomerId == appUser.Id).ToList();
            foreach (var order in orders)
            {
                string paymentMethod = _paymentService.GetPaymentNameWithId(order.PaymentId);
                string orderOwnerFullName = _appUserService.GetOrderOwnerFullNameWithUserId(order.CustomerId);

                model.Add(new OrderSummaryViewModel()
                {
                    OrderId = order.Id,
                    OrderDate = order.OrderDate,
                    PaymentMethod = paymentMethod,
                    CustomerFullName = orderOwnerFullName,
                    ShipStatus = order.IsShipped ? "Kargoya Verildi" : "Kargoya Verilmedi",
                    AllowStatus = order.IsAllowed ? "Onaylandı" : "Onay Bekliyor",
                });
            }

            return model;
        }

    }
}