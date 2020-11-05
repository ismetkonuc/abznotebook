using System;
using System.Collections.Generic;
using System.Text;
using Project.TechnoStore.Entities.Interfaces;

namespace Project.TechnoStore.Entities.Concrete
{
    public class Shipper : ITable
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public List<Order> Orders { get; set; }
    }
}
