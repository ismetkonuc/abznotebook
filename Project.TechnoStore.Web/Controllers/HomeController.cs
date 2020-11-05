using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Web.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            using var db = new TechnoStoreDbContext();


            return View(db.Products.Where(I=>I.IsAvailable == true).ToList());
        }
    }
}
