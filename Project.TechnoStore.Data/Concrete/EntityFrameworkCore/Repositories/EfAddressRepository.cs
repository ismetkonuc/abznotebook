using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAddressRepository : EfGenericRepository<Address>, IAddressDal
    {
        private TechnoStoreDbContext _context;

        public EfAddressRepository(TechnoStoreDbContext context)
        {
            _context = context;
        }

        public List<Address> GetAddressesByUserId(int userId)
        {
            return _context.Addresses.Where(I => I.AppUser.Id == userId).ToList();
        }
    }
}
