using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.TechnoStore.Web.Areas.Admin.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }

    }
}
