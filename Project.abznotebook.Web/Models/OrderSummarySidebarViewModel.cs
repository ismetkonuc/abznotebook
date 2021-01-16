using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.abznotebook.Web.Models
{
    public class OrderSummarySidebarViewModel
    {
        public List<ProductSummaryViewModel> ProductSummaries { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
