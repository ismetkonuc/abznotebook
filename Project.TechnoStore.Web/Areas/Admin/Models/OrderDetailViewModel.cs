using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Web.Areas.Admin.Models
{
    public class OrderDetailViewModel : OrderSummaryViewModel
    {
        public Address Address { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public Shipper Shipper { get; set; }
        public List<BillViewModel> Bill { get; set; }
    }
}
