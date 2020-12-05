using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Entities.Concrete;
using Project.TechnoStore.Web.Areas.Admin.Infrastructure;
using Project.TechnoStore.Web.Areas.Admin.Models;
using System;
using System.IO;
using System.Linq;

namespace Project.TechnoStore.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class OperationsController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public OperationsController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment WebHostEnvironment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _WebHostEnvironment = WebHostEnvironment;
        }

        [Route("admin/islemler")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("admin/islemler/urunler")]
        public IActionResult Product(string sortOrder, string searchString)
        {

            ViewBag.IdSort = sortOrder == "IdSort" ? "id_desc" : "IdSort";
            ViewBag.NameSort = sortOrder == "NameSort" ? "name_desc" : "NameSort";
            ViewBag.StockSort = sortOrder == "StockSort" ? "stock_desc" : "StockSort";
            ViewBag.VendorSort = sortOrder == "VendorSort" ? "vendor_desc" : "VendorSort";
            ViewBag.StockStatusSort = sortOrder == "StockStatusSort" ? "stockstatus_desc" : "StockStatusSort";
            ViewBag.PriceSort = sortOrder == "PriceSort" ? "price_desc" : "PriceSort";

            ViewBag.FromSearch = searchString;

            return View(this.sortByParameters(sortOrder, searchString));
        }

        [HttpGet]
        [Route("admin/islemler/urunekle")]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = new SelectList(_categoryService.GetAllCategories.ToList(), "Id", "Name");
            ViewBag.Memories = new SelectList(ProductDetailPack.MemoryList, "Seç");
            ViewBag.Vendors = new SelectList(ProductDetailPack.VendorList, "Seç");
            ViewBag.ProcessorVendors = new SelectList(ProductDetailPack.ProcessorVendorList, "Seç");
            ViewBag.DiscCapacities = new SelectList(ProductDetailPack.DiscCapacityList, "Seç");
            return View(new AddProductViewModel());
        }

        [HttpPost]
        [Route("admin/islemler/urunekle")]
        public IActionResult AddProduct(AddProductViewModel model)
        {

            if (ModelState.IsValid)
            {
                string[] uniqueFileNames = UploadedFile(model);

                if (uniqueFileNames.Length < 3)
                {

                }

                _productService.Save(new Product()
                {
                    Name = model.Name,
                    SKU = model.SKU,
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    DiscCapacity = model.DiscCapacity,
                    IsAvailable = model.IsAvailable,
                    GraphicsCard = model.GraphicsCard,
                    MemoryCapacity = model.MemoryCapacity,
                    ProcessorType = model.ProcessorType,
                    ProcessorVendor = model.ProcessorVendor,
                    UnitInStock = model.UnitInStock,
                    Vendor = model.Vendor,
                    UnitPrice = model.UnitPrice,
                    Image1 = uniqueFileNames[0],
                    Image2 = uniqueFileNames[1],
                    Image3 = uniqueFileNames[2]
                });
                return RedirectToAction("Product");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            Product product = _productService.GetSpesificProduct(id);

            EditProductViewModel model = new EditProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Vendor = product.Vendor,
                CategoryId = product.CategoryId,
                ProcessorVendor = product.ProcessorVendor,
                ProcessorType = product.ProcessorType,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                IsAvailable = product.IsAvailable,
                DiscCapacity = product.DiscCapacity,
                MemoryCapacity = product.MemoryCapacity,
                UnitInStock = product.UnitInStock,
                GraphicsCard = product.GraphicsCard,
                Image1 = product.Image1,
                Image2 = product.Image2,
                Image3 = product.Image3,
                SKU = product.SKU
            };

            ViewBag.Categories = new SelectList(_categoryService.GetAllCategories.ToList(), "Id", "Name");
            ViewBag.Memories = new SelectList(ProductDetailPack.MemoryList, "Seç");
            ViewBag.Vendors = new SelectList(ProductDetailPack.VendorList, "Seç");
            ViewBag.ProcessorVendors = new SelectList(ProductDetailPack.ProcessorVendorList, "Seç");
            ViewBag.DiscCapacities = new SelectList(ProductDetailPack.DiscCapacityList, "Seç");

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(new Product()
                {
                    Id = model.Id,
                    UnitPrice = model.UnitPrice,
                    CategoryId = model.CategoryId,
                    Name = model.Name,
                    IsAvailable = model.IsAvailable,
                    Description = model.Description,
                    GraphicsCard = model.GraphicsCard,
                    MemoryCapacity = model.MemoryCapacity,
                    DiscCapacity = model.DiscCapacity,
                    UnitInStock = model.UnitInStock,
                    ProcessorVendor = model.ProcessorVendor,
                    Vendor = model.Vendor,
                    ProcessorType = model.ProcessorType,
                    Image1 = model.Image1,
                    Image2 = model.Image2,
                    Image3 = model.Image3,
                    SKU = model.SKU
                });
                return RedirectToAction("Product");
            }

            ViewBag.Categories = new SelectList(_categoryService.GetAllCategories.ToList(), "Id", "Name");
            ViewBag.Memories = new SelectList(ProductDetailPack.MemoryList, "Seç");
            ViewBag.Vendors = new SelectList(ProductDetailPack.VendorList, "Seç");
            ViewBag.ProcessorVendors = new SelectList(ProductDetailPack.ProcessorVendorList, "Seç");
            ViewBag.DiscCapacities = new SelectList(ProductDetailPack.DiscCapacityList, "Seç");

            return View(model);
        }

        public IActionResult DeleteProduct(int id)
        {
            _productService.Delete(new Product{Id = id});
            return RedirectToAction("Product");
        }


        public IActionResult Category()
        {
            ViewBag.CountOfCat1 = _productService.GetProductsByCategoryId(1).Count;
            ViewBag.CountOfCat2 = _productService.GetProductsByCategoryId(2).Count;

            return View(_categoryService.GetAllCategories);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View(new AddCategoryViewModel());
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Save(new Category()
                {
                    Name = model.Name,
                    Description = model.Description
                });
                return RedirectToAction("Category");
            }
            return View(model);
        }

        private string[] UploadedFile(AddProductViewModel model)
        {
            //string uniqueFileName = null;
            string[] uniqueFileNames = new string[3];

            //if (model.Image1 != null)
            //{
            //    string uploadsFolder = Path.Combine(_WebHostEnvironment.WebRootPath, "img");
            //    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image1.FileName;
            //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        model.Image1.CopyTo(fileStream);
            //    }
            //}

            if (model.Images != null && model.Images.Count > 0)
            {

                int countOfImages = model.Images.Count;

                if (countOfImages > 3)
                {
                    countOfImages = 3;
                }


                for (int i = 0; i < countOfImages; i++)
                {
                    uniqueFileNames[i] = null;
                    string uploadsFolder = Path.Combine(_WebHostEnvironment.WebRootPath, "img");
                    uniqueFileNames[i] = Guid.NewGuid().ToString() + "_" + model.Images[i].FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileNames[i]);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.Images[i].CopyTo(fileStream);
                    }
                }

            }

            return uniqueFileNames;
        }

        private IQueryable<Product> sortByParameters(string sortOrder, string searchString)
        {
            var products = _productService.Products;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(I => I.SKU.Contains(searchString) || I.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderBy(I => I.Name);
                    break;
                case "NameSort":
                    products = products.OrderByDescending(I => I.Name);
                    break;
                case "StockSort":
                    products = products.OrderBy(P => P.UnitInStock);
                    break;
                case "stock_desc":
                    products = products.OrderByDescending(I => I.UnitInStock);
                    break;
                case "vendor_desc":
                    products = products.OrderBy(I => I.Vendor);
                    break;
                case "VendorSort":
                    products = products.OrderByDescending(I => I.Vendor);
                    break;
                case "stockstatus_desc":
                    products = products.OrderBy(I => I.UnitInStock);
                    break;
                case "StockStatusSort":
                    products = products.OrderByDescending(I => I.UnitInStock);
                    break;
                case "id_desc":
                    products = products.OrderBy(I => I.Id);
                    break;
                case "IdSort":
                    products = products.OrderByDescending(I => I.Id);
                    break;
                case "price_desc":
                    products = products.OrderBy(I => I.UnitPrice);
                    break;
                case "PriceSort":
                    products = products.OrderByDescending(I => I.UnitPrice);
                    break;
                default:
                    products = products.OrderByDescending(I => I.Id);
                    break;
            }

            return products;
        }
    }
}
