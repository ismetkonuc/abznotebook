using System.Collections.Generic;
using Project.TechnoStore.Business.Interfaces;
using Project.TechnoStore.Data.Interfaces;
using Project.TechnoStore.Entities.Concrete;

namespace Project.TechnoStore.Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public void Save(Payment table)
        {
            _paymentDal.Save(table);
        }

        public void Delete(Payment table)
        {
            _paymentDal.Delete(table);
        }

        public void Update(Payment table)
        {
            _paymentDal.Update(table);
        }

        public Payment GetOrderWithId(int id)
        {
            return _paymentDal.GetOrderWithId(id);
        }

        public List<Payment> GetAllOrders()
        {
            return _paymentDal.GetAllOrders();
        }

        public List<Payment> GetAllPayments()
        {
            return _paymentDal.GetAllPayments();
        }
    }
}