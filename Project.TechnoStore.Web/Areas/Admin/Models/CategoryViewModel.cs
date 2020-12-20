using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Web.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CountOfProduct { get; set; }

        //public List<Product> Products { get; set; }
    }
}
