using System.Collections.Generic;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Interfaces
{
    public interface IPaymentDal : IGenericDal<Payment>
    {
        List<Payment> GetAllPayments();
    }
}