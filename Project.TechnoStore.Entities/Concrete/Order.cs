using System;
using System.Collections.Generic;
using System.Text;
using Project.TechnoStore.Entities.Interfaces;

namespace Project.TechnoStore.Entities.Concrete
{
    public class Order : ITable
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public bool IsShipped { get; set; } = false;
        public List<OrderDetail> OrderDetails { get; set; }
        
        public int? CustomerId { get; set; }
        public AppUser Customer { get; set; }

        public int? ShipperId { get; set; }
        public Shipper Shipper { get; set; }

    }
}
