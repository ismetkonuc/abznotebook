using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.abznotebook.Business.Interfaces;
using Project.abznotebook.Entities.Concrete;
using Project.abznotebook.Web.Models;

namespace Project.abznotebook.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService _productService;
        public int pageSize = 6;
        List<FilterViewModel> models = new List<FilterViewModel>();
        public CategoryController(IProductService productService)
        {
            _productService = productService;
        }

        
        [HttpGet]
        public ViewResult Gaming(int productPage = 1, string sortOrder = "", FilterViewModel model=null)
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
                },
                FilterTypes = new FilterViewModel()
                {
                    Vendors = _productService.Products.Select(I => I.Vendor).Distinct().OrderBy(I => I).ToList(),
                    Memories = _productService.Products.Select(I => I.MemoryCapacity).Distinct().OrderBy(I => I).ToList(),
                }
            };

            ViewBag.Vendors = new SelectList(productList.FilterTypes.Vendors);
            ViewBag.Memories = new SelectList(productList.FilterTypes.Memories);

            if (!string.IsNullOrEmpty(model.SelectedVendor))
            {
                productList.Products = productList.Products.Where(I => I.Vendor.Contains(model.SelectedVendor));
            }

            if (!string.IsNullOrEmpty(model.SelectedMemory))
            {
                productList.Products = productList.Products.Where(I => I.MemoryCapacity == model.SelectedMemory);
            }

            ViewBag.OrderStatus = "En İyi Eşleşme";

            switch (sortOrder)
            {
                case "best_match":
                    productList.Products = productList.Products.OrderByDescending(P => P.CreatedDate);
                    ViewBag.OrderStatus = "En İyi Eşleşme";
                    break;

                case "desc_price":
                    productList.Products = productList.Products.OrderByDescending(p => p.UnitPrice);
                    ViewBag.OrderStatus = "Fiyat: Azalan";
                    break;
                case "asc_price":
                    productList.Products = productList.Products.OrderBy(p => p.UnitPrice);
                    ViewBag.OrderStatus = "Fiyat: Artan";
                    break;
            }



            return View(productList);
        }

        [HttpGet]
        public ViewResult HomeOffice(int productPage = 1, string sortOrder = "", FilterViewModel model = null)
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
                },
                FilterTypes = new FilterViewModel()
                {
                    Vendors = _productService.Products.Select(I => I.Vendor).Distinct().OrderBy(I => I).ToList(),
                    Memories = _productService.Products.Select(I => I.MemoryCapacity).Distinct().OrderBy(I => I).ToList(),
                }
            };

            ViewBag.Vendors = new SelectList(productList.FilterTypes.Vendors);
            ViewBag.Memories = new SelectList(productList.FilterTypes.Memories);

            if (!string.IsNullOrEmpty(model.SelectedVendor))
            {
                productList.Products = productList.Products.Where(I => I.Vendor.Contains(model.SelectedVendor));
            }

            if (!string.IsNullOrEmpty(model.SelectedMemory))
            {
                productList.Products = productList.Products.Where(I => I.MemoryCapacity == model.SelectedMemory);
            }

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

        public ViewResult TwoInOne(int productPage = 1, string sortOrder = "", FilterViewModel model = null)
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
                },
                FilterTypes = new FilterViewModel()
                {
                    Vendors = _productService.Products.Select(I => I.Vendor).Distinct().OrderBy(I => I).ToList(),
                    Memories = _productService.Products.Select(I => I.MemoryCapacity).Distinct().OrderBy(I => I).ToList(),
                }
            };

            ViewBag.Vendors = new SelectList(productList.FilterTypes.Vendors);
            ViewBag.Memories = new SelectList(productList.FilterTypes.Memories);

            if (!string.IsNullOrEmpty(model.SelectedVendor))
            {
                productList.Products = productList.Products.Where(I => I.Vendor.Contains(model.SelectedVendor));
            }

            if (!string.IsNullOrEmpty(model.SelectedMemory))
            {
                productList.Products = productList.Products.Where(I => I.MemoryCapacity == model.SelectedMemory);
            }

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
