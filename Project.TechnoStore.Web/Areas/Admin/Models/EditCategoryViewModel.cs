using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.TechnoStore.Web.Areas.Admin.Models
{
    public class EditCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
