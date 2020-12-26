using System.Collections.Generic;
using System.Threading.Channels;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Interfaces
{
    public interface ICouponDal : IGenericDal<Coupon>
    {
        public List<Coupon> GetAllCoupons();
    }
}