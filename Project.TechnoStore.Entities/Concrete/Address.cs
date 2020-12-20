using System;
using System.Collections.Generic;
using System.Text;
using Project.TechnoStore.Entities.Interfaces;

namespace Project.TechnoStore.Entities.Concrete
{
    public class Address : ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string PostalCode { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
