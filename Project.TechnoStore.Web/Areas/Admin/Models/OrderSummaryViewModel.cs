using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.TechnoStore.Web.Areas.Admin.Models
{
    public class OrderSummaryViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public bool IsShipped { get; set; }
        public bool IsAllowed { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string PaymentMethod { get; set; }
        public int AddressId { get; set; }
    }
}
