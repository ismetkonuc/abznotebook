using System.Collections.Generic;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Concrete
{
    public class ShipperManager : IShipperService
    {
        private readonly IShipperDal _shipperDal;

        public ShipperManager(IShipperDal shipperDal)
        {
            _shipperDal = shipperDal;
        }
        public void Save(Shipper table)
        {
            _shipperDal.Save(table);
        }

        public void Delete(Shipper table)
        {
            _shipperDal.Delete(table);
        }

        public void Update(Shipper table)
        {
            _shipperDal.Update(table);
        }

        public Shipper GetOrderWithId(int id)
        {
            return _shipperDal.GetOrderWithId(id);
        }

        public List<Shipper> GetAllOrders()
        {
            return _shipperDal.GetAllOrders();
        }

        public List<Shipper> GetAllShippers()
        {
            return _shipperDal.GetAllShippers();
        }
    }
}