﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Web.Areas.Admin.Models
{
    public class CustomerOrdersViewModel : UserViewModel
    {
        public List<Order> Orders { get; set; }

    }
}
