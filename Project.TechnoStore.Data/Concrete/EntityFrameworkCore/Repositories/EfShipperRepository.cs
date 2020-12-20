using System.Collections.Generic;
using System.Linq;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class EfShipperRepository:EfGenericRepository<Shipper>, IShipperDal
    {
        private readonly TechnoStoreDbContext _dbContext;

        public EfShipperRepository(TechnoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Shipper> GetAllShippers()
        {
            return _dbContext.Shippers.ToList();
        }
    }
}