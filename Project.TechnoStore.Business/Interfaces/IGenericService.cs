using System.Collections.Generic;
using Project.TechnoStore.Entities.Interfaces;

namespace Project.TechnoStore.Business.Interfaces
{
    public interface IGenericService<Table> where Table : class, ITable, new()
    {
        void Save(Table table);
        void Delete(Table table);
        void Update(Table table);
        Table GetOrderWithId(int id);
        List<Table> GetAllOrders();
    }
}