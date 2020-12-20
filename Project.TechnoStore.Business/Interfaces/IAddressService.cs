using System.Collections.Generic;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Interfaces
{
    public interface IAddressService : IGenericService<Address>
    {
        List<Address> GetAddressesByUserId(int userId);
    }
}