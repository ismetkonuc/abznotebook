using System;
using System.Collections.Generic;
using System.Text;
using Project.TechnoStore.Entities.Interfaces;

namespace Project.TechnoStore.Entities.Concrete
{
    public class OrderDetail : ITable
    {
        public int OrderNumber { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }



        public int? ProductId { get; set; }
        public Product Product { get; set; }

        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
