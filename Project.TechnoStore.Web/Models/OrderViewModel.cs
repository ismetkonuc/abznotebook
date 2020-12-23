using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Web.Models
{
    public class OrderViewModel
    {
        public int AddressId { get; set; }
        public int ShipperId { get; set; }
        public int PaymentId { get; set; }
        public int? LinesCount { get; set; }
    }
}
