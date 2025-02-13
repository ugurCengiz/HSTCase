using Business.Servies.Abstract;
using Core.UnitOfWorks;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Servies.Concrete
{
  public  class PaymentManager : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentManager(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork = null)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
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
            _unitOfWork.SaveChanges();
            return addedPayment;
        }

        public Payment Delete(Payment payment)
        {
            _paymentRepository.Delete(payment);
            _unitOfWork.SaveChanges();
            return payment;
        }



        public Payment Update(Payment payment)
        {
            Payment updatedPayment = _paymentRepository.Update(payment);
            _unitOfWork.SaveChanges();
            return updatedPayment;
        }
    }
}
