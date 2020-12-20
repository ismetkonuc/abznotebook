using System.Collections.Generic;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Interfaces
{
    public interface IPaymentService : IGenericService<Payment>
    {
        List<Payment> GetAllPayments();
    }
}