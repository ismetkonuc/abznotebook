using System;
using System.Collections.Generic;
using System.Text;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Interfaces
{
    public interface IOrderService : IGenericService<Order>
    {
        List<Order> GetUnshippedOrders();
        List<Order> GetShippedOrders();
    }
}
