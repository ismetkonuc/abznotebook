using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Entities.Concrete;
using Project.TechnoStore.Web.Models;
using System.Linq;
using System.Net;

namespace Project.TechnoStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public int pageSize = 6;

        public HomeController(IProductService productService, Cart cart)
        {
            _productService = productService;
        }


        public IActionResult Index(int productPage = 1, string sortOrder = "")
        {

            ProductListViewModel productList = new ProductListViewModel()
            {
                Products =
                    _productService.Products.OrderBy(p => p.Id).Skip((productPage - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = productPage,
                    ItemsPerPage = pageSize,
                    TotalItems = _productService.Products.Count()
                }
            };


            ViewBag.OrderStatus = "En İyi Eşleşme";

            switch (sortOrder)
            {
                case "best_match":
                    productList.Products = _productService.Products.OrderByDescending(P => P.CreatedDate);
                    ViewBag.OrderStatus = "En İyi Eşleşme";
                    break;

                case "desc_price":
                    productList.Products = _productService.Products.OrderByDescending(p => p.UnitPrice);
                    ViewBag.OrderStatus = "Fiyat: Azalan";
                    break;
                case "asc_price":
                    productList.Products = _productService.Products.OrderBy(p => p.UnitPrice);
                    ViewBag.OrderStatus = "Fiyat: Artan";
                    break;
            }

            return View(productList);
        }

        public IActionResult Product(int productId = 1, string name = "")
        {
            name = WebUtility.UrlEncode(name);
            var product = _productService.Products.Single(I => I.Id == productId);
            return View(product);
        }

    }
}
