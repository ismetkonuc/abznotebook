using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.abznotebook.Entities.Concrete;

namespace Project.abznotebook.Web.Models
{
    public class DeliveryViewModel
    {
        public int AddressId { get; set; } // Selected Address
        public int ShipperId { get; set; } // Selected Shipper
        public int? LinesCount { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public SelectList ShipperCollection { get; set; }
        public SelectList AddressCollection { get; set; }
    }
}
