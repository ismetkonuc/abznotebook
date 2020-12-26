using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Interfaces
{
    public interface IAppUserService
    {
        List<Order> GetGivenCustomersOrders(AppUser user);
        string GetOrderOwnerFullNameWithUserId(int userId);
        Task<List<AppUser>> GetUsersAsync();

    }
}
