using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class EfOrderRepository : EfGenericRepository<Order>, IOrderDal
    {
        public List<Order> GetUnshippedOrders()
        {
            using var db = new TechnoStoreDbContext();

            return db.Orders.Where(I => I.IsShipped == false).ToList();
        }

        public List<Order> GetShippedOrders()
        {
            using var db = new TechnoStoreDbContext();

            return db.Orders.Where(I => I.IsShipped == true).ToList();
        }
    }
}