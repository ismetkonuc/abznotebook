using System;
using System.Collections.Generic;
using System.Text;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Interfaces
{
    public interface IAppUserDal
    {
        List<Order> GetGivenCustomersOrders(AppUser user);
    }
}
