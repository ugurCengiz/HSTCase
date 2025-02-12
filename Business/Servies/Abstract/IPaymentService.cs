using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Servies.Abstract
{
    public interface IPaymentService
    {
        Task<Payment?> GetAsync(Expression<Func<Payment, bool>> predicate);
        Task<List<Payment>?> GetListAsync(Expression<Func<Payment, bool>>? predicate = null);
        Payment Add(Payment payment);
        Payment Update(Payment payment);
        Payment Delete(Payment payment);
    }
}
