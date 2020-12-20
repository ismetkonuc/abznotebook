using System.Collections.Generic;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Interfaces
{
    public interface IShipperDal : IGenericDal<Shipper>
    {
        List<Shipper> GetAllShippers();
    }
}