using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Project.TechnoStore.Entities.Interfaces;

namespace Project.TechnoStore.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; } = "default.png";
        public List<Address> Addresses { get; set; }

        public List<Order> Orders { get; set; }

    }
}
