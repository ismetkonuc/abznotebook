using System;
using System.Collections.Generic;
using System.Text;
using Project.TechnoStore.Entities.Interfaces;

namespace Project.TechnoStore.Entities.Concrete
{
    public class Payment : ITable
    {
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }

        public List<Order> Orders { get; set; }
    }
}
