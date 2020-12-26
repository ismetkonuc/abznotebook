using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        private readonly TechnoStoreDbContext _db;

        public EfAppUserRepository(TechnoStoreDbContext db)
        {
            _db = db;
        }

        public async Task<List<AppUser>> GetUsersAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public List<Order> GetGivenCustomersOrders(AppUser user)
        {
            return _db.Users.Single(I => I.Id == user.Id).Orders.ToList();
        }

        public string GetOrderOwnerFullNameWithUserId(int userId)
        {
            AppUser user = _db.Users.Single(I => I.Id == userId);
            return $"{user.Name} {user.Surname}";
        }
    }
}
