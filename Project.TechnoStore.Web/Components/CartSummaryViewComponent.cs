using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.TechnoStore.Web.Models;

namespace Project.TechnoStore.Web.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
