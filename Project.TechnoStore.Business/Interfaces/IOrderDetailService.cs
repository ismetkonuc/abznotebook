using System.Collections.Generic;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Interfaces
{
    public interface IOrderDetailService : IGenericService<OrderDetail>
    {
        List<OrderDetail> GetAllOrderDetails();
    }
}