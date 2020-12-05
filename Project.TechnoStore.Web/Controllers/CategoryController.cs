using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.TechnoStore.Business.Interfaces;

namespace Project.TechnoStore.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService _productService;

        public CategoryController(IProductService productService)
        {
            _productService = productService;
        }

        public ViewResult Computer() => View(_productService.Products);

        public ViewResult Gaming() => View(_productService.GetProductsByCategoryId(1));

        public ViewResult HomeOffice() => View(_productService.GetProductsByCategoryId(2));
    }
}
