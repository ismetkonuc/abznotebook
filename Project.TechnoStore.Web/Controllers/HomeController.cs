using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;
using Project.TechnoStore.Web.Models;

namespace Project.TechnoStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {

            var products = _productService.GetAllProducts();

            List<ProductListViewModel> model = new List<ProductListViewModel>();

            foreach (var product in products)
            {
                ProductListViewModel singleProduct = new ProductListViewModel()
                {
                    Id = product.Id,
                    IsAvailable = product.IsAvailable,
                    CategoryId = product.CategoryId,
                    UnitPrice = product.UnitPrice,
                    Name = product.Name,
                    UnitInStock = product.UnitInStock,
                    Processor = product.ProcessorType,
                    Vendor = product.Vendor,
                    GraphicsCard = product.GraphicsCard,
                    MemoryCapacity = product.MemoryCapacity,
                    DiscCapacity = product.DiscCapacity,
                    Picture = product.Picture,
                    Description = product.Description,
                    ProcessorVendor = product.ProcessorVendor,
                    QuantityPerUnit = product.QuantityPerUnit,
                    Category = product.Category,
                    SKU = product.SKU
                };
                model.Add(singleProduct);
            }

            return View(model);
        }
    }
}
