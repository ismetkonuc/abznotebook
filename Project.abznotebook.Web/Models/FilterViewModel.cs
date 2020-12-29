using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.abznotebook.Entities.Concrete;

namespace Project.abznotebook.Web.Models
{
    public class FilterViewModel
    {
        public List<string> Vendors { get; set; }
        public List<string> Memories { get; set; }
        //public List<string> ProcessorVendors { get; set; }
        //public List<string> ProcessorTypes { get; set; }
        //public List<string> GraphicsCards { get; set; }
        //public List<string> MemoryCapacities { get; set; }
        //public List<string> DiscCapacities { get; set; }

    }
}
