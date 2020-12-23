using System;
using System.Collections.Generic;
using System.Text;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Interfaces
{
    public interface IAppUserService
    {
        List<Order> GetGivenCustomersOrders(AppUser user);
        string GetOrderOwnerFullNameWithUserId(int userId);
    }
}
