using System.Collections.Generic;
using System.Linq;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class EfOrderDetailRepository : EfGenericRepository<OrderDetail>, IOrderDetailDal
    {
        private readonly TechnoStoreDbContext _dbContext;

        public EfOrderDetailRepository(TechnoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _dbContext.OrderDetails.ToList();
        }
    }
}