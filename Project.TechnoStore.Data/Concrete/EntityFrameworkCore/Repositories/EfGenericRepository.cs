using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Interfaces;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Table> : IGenericDal<Table> where Table : class, ITable, new()
    {
        public void Save(Table table)
        {
            using var db = new TechnoStoreDbContext();
            db.Set<Table>().Add(table);
            db.SaveChanges();
        }

        public void Delete(Table table)
        {
            using var db = new TechnoStoreDbContext();
            db.Set<Table>().Remove(table);
            db.SaveChanges();
        }

        public void Update(Table table)
        {
            using var db = new TechnoStoreDbContext();
            db.Set<Table>().Update(table);
            db.SaveChanges();
        }

        public Table GetOrderWithId(int id)
        {
            using var db = new TechnoStoreDbContext();
            return db.Set<Table>().Find(id);
        }

        public List<Table> GetAllOrders()
        {
            using var db = new TechnoStoreDbContext();
            return db.Set<Table>().ToList();
        }
    }
}
