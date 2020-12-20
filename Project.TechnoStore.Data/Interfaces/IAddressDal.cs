using System.Collections.Generic;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Interfaces
{
    public interface IAddressDal : IGenericDal<Address>
    {
        List<Address> GetAddressesByUserId(int userId);
    }
}