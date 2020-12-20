using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<Order> GetGivenCustomersOrders(AppUser user)
        {
            using var context = new TechnoStoreDbContext();

            return context.Users.Where(I => I.Id == user.Id).FirstOrDefault().Orders.ToList();
        }

    }
}
