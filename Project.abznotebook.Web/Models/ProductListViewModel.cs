using System.Collections.Generic;
using System.Linq;
using Project.abznotebook.Entities.Concrete;

namespace Project.abznotebook.Web.Models
{
    public class ProductListViewModel
    {

        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public FilterViewModel FilterTypes { get; set; }
        //public int Id { get; set; }
        //public string SKU { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public string Vendor { get; set; }
        //public string ProcessorVendor { get; set; }
        //public string Processor { get; set; }
        //public string GraphicsCard { get; set; }
        //public string MemoryCapacity { get; set; }
        //public string DiscCapacity { get; set; }
        //public string Picture { get; set; }
        //public int QuantityPerUnit { get; set; }
        //public decimal UnitPrice { get; set; }
        //public int UnitInStock { get; set; }
        //public bool IsAvailable { get; set; }

        //public int? CategoryId { get; set; }
        //public Category Category { get; set; }
    }
}