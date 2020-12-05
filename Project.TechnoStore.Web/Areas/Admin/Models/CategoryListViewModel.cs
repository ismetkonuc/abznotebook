using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Web.Areas.Admin.Models
{
    public class CategoryListViewModel
    {
        public IQueryable<Category> Categories { get; set; }
        public List<int> CountOfProductByCategory { get; set; }
    }
}
