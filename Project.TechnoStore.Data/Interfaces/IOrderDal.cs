using System;
using System.Collections.Generic;
using System.Text;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Interfaces
{
    public interface IOrderDal : IGenericDal<Order>
    {
        List<Order> GetUnshippedOrders();
        List<Order> GetShippedOrders();
        List<Order> GetAllowedOrders();
    }
}
