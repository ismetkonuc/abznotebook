using System.Collections.Generic;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Interfaces
{
    public interface IShipperService : IGenericService<Shipper>
    {
        List<Shipper> GetAllShippers();
    }
}