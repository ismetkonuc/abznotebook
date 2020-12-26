using System.Collections.Generic;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Interfaces
{
    public interface ICouponService : IGenericService<Coupon>
    { 
        public List<Coupon> GetAllCoupons();
    }
}