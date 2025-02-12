using Business.Servies.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Servies.Concrete
{
    class PaymentManager : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentManager(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment?> GetAsync(Expression<Func<Payment, bool>> predicate)
        {
            Payment? payment = await _paymentRepository.GetAsync(predicate);
            return payment;
        }

        public async Task<List<Payment>?> GetListAsync(Expression<Func<Payment, bool>>? predicate = null)
        {
            IEnumerable<Payment> payments = await _paymentRepository.GetListAsync(predicate);
            return payments.ToList();
        }
        public Payment Add(Payment payment)
        {
            Payment addedPayment = _paymentRepository.Add(payment);
            return addedPayment;
        }

        public Payment Delete(Payment payment)
        {
            _paymentRepository.Delete(payment);
            return payment;
        }



        public Payment Update(Payment payment)
        {
            Payment updatedPayment = _paymentRepository.Update(payment);
            return updatedPayment;
        }
    }
}
