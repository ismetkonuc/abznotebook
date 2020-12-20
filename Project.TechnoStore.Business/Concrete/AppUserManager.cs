using System;
using System.Collections.Generic;
using System.Text;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public List<Order> GetGivenCustomersOrders(AppUser user)
        {
            return _appUserDal.GetGivenCustomersOrders(user);
        }

    }
}
