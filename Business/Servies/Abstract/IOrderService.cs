using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Servies.Abstract
{
    public interface IOrderService
    {
        Task<Order?> GetAsync(Expression<Func<Order, bool>> predicate);
        Task<List<Order>?> GetListAsync(Expression<Func<Order, bool>>? predicate = null);
        Order Add(Order order);
        Order Update(Order order);
        Order Delete(Order order);
    }
}
