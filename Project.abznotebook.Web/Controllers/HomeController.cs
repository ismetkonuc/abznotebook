using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.abznotebook.Entities.Concrete;
using System.Linq;
using System.Net;
using Project.abznotebook.Business.Interfaces;
using Project.abznotebook.Web.Models;

namespace Project.abznotebook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public int pageSize = 6;

        public HomeController(IProductService productService, Cart cart)
        {
            _productService = productService;
        }


        public IActionResult Index(int productPage = 1, string sortOrder = "", string vendorFilter = "", string memoryFilter="") //vendorFilter = "Asus"
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
                },
                FilterTypes = new FilterViewModel()
                {
                    Vendors = _productService.Products.Select(I => I.Vendor).Distinct().OrderBy(I => I).ToList(),
                    Memories = _productService.Products.Select(I=>I.MemoryCapacity).Distinct().OrderBy(I=>I).ToList()
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


            if (!vendorFilter.Equals(""))
            {
                productList.Products = _productService.Products.Where(I => I.Vendor.Equals(vendorFilter)).ToList();
            }

            if (!memoryFilter.Equals(""))
            {
                productList.Products =
                    _productService.Products.Where(I => I.MemoryCapacity.Equals(memoryFilter)).ToList();
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
