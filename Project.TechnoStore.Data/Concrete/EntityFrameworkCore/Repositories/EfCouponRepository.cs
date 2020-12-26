using System.Collections.Generic;
using System.Linq;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCouponRepository : EfGenericRepository<Coupon>, ICouponDal
    {
        private readonly TechnoStoreDbContext _dbContext;

        public EfCouponRepository(TechnoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Coupon> GetAllCoupons()
        {
            return _dbContext.Coupons.ToList();
        }
    }
}