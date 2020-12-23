using System.Collections.Generic;
using System.Linq;
using Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Contexts;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Data.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPaymentRepository : EfGenericRepository<Payment>, IPaymentDal
    {
        private readonly TechnoStoreDbContext _dbContext;
        public EfPaymentRepository(TechnoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Payment> GetAllPayments()
        {
            return _dbContext.Payments.ToList();
        }

        public string GetPaymentNameWithId(int? paymentId)
        {
            return _dbContext.Payments.Single(I => I.PaymentId == paymentId).PaymentType;
        }
    }
}