using System;
using System.Collections.Generic;
using System.Text;
using Project.TechnoStore.Entities.Interfaces;

namespace Project.TechnoStore.Entities.Concrete
{
    public class Product : ITable
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public int IDSKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public string ProcessorVendor { get; set; }
        public string ProcessorModel { get; set; }
        public string ProcessorType { get; set; }
        public string GraphicsCard { get; set; }
        public string MemoryCapacity { get; set; }
        public string DiscCapacity { get; set; }
        public string Picture { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public bool IsAvailable { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }



    }
}
