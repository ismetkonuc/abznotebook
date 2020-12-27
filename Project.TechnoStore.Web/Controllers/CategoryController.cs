using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Web.Models;

namespace Project.TechnoStore.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService _productService;
        public int pageSize = 6;

        public CategoryController(IProductService productService)
        {
            _productService = productService;
        }

        public ViewResult Gaming(int productPage = 1, string sortOrder = "")
        {

            ProductListViewModel productList = new ProductListViewModel()
            {
                Products =
                    _productService.GetProductsByCategoryId(1).OrderBy(p => p.Id).Skip((productPage - 1) * pageSize).Take(pageSize),
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
                    productList.Products = _productService.GetProductsByCategoryId(1).OrderByDescending(P => P.CreatedDate);
                    ViewBag.OrderStatus = "En İyi Eşleşme";
                    break;

                case "desc_price":
                    productList.Products = _productService.GetProductsByCategoryId(1).OrderByDescending(p => p.UnitPrice);
                    ViewBag.OrderStatus = "Fiyat: Azalan";
                    break;
                case "asc_price":
                    productList.Products = _productService.GetProductsByCategoryId(1).OrderBy(p => p.UnitPrice);
                    ViewBag.OrderStatus = "Fiyat: Artan";
                    break;
            }

            return View(productList);
        }

        public ViewResult HomeOffice(int productPage = 1, string sortOrder = "")
        {

            ProductListViewModel productList = new ProductListViewModel()
            {
                Products =
                    _productService.GetProductsByCategoryId(2).OrderBy(p => p.Id).Skip((productPage - 1) * pageSize).Take(pageSize),
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
                    productList.Products = _productService.GetProductsByCategoryId(2).OrderByDescending(P => P.CreatedDate);
                    ViewBag.OrderStatus = "En İyi Eşleşme";
                    break;

                case "desc_price":
                    productList.Products = _productService.GetProductsByCategoryId(2).OrderByDescending(p => p.UnitPrice);
                    ViewBag.OrderStatus = "Fiyat: Azalan";
                    break;
                case "asc_price":
                    productList.Products = _productService.GetProductsByCategoryId(2).OrderBy(p => p.UnitPrice);
                    ViewBag.OrderStatus = "Fiyat: Artan";
                    break;
            }

            return View(productList);
        }

        public ViewResult TwoInOne(int productPage = 1, string sortOrder = "")
        {
            ProductListViewModel productList = new ProductListViewModel()
            {
                Products =
                    _productService.GetProductsByCategoryId(3).OrderBy(p => p.Id).Skip((productPage - 1) * pageSize).Take(pageSize),
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
                    productList.Products = _productService.GetProductsByCategoryId(3).OrderByDescending(P => P.CreatedDate);
                    ViewBag.OrderStatus = "En İyi Eşleşme";
                    break;

                case "desc_price":
                    productList.Products = _productService.GetProductsByCategoryId(3).OrderByDescending(p => p.UnitPrice);
                    ViewBag.OrderStatus = "Fiyat: Azalan";
                    break;
                case "asc_price":
                    productList.Products = _productService.GetProductsByCategoryId(3).OrderBy(p => p.UnitPrice);
                    ViewBag.OrderStatus = "Fiyat: Artan";
                    break;
            }

            return View(productList);
        }
    }
}
