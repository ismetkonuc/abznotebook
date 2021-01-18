using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.abznotebook.Entities.Concrete;

namespace Project.abznotebook.Web.Areas.Member.Models
{
    public class EditOrderAddressViewModel : Address
    {
        public int OrderId { get; set; }
    }
}
