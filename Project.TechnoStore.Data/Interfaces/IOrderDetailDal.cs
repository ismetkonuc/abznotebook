using System.Collections.Generic;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Interfaces
{
    public interface IOrderDetailDal : IGenericDal<OrderDetail>
    {
        List<OrderDetail> GetAllOrderDetails();
        dynamic GetGivenUsersDetailedOrder(AppUser user);
        decimal ComputeTotalPriceOfOrder(int orderId);
    }
}