using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Web.Base.Common.Models
{
    public class BillViewModel
    {
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
