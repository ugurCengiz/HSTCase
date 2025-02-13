using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Business.Servies.Abstract
{
    public interface IOrderService
    {
        Task<Order?> GetAsync(Expression<Func<Order, bool>> predicate, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null);
        Task<List<Order>?> GetListAsync(Expression<Func<Order, bool>>? predicate = null, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null);
        Order Add(Order order);
        Order Update(Order order);
        Order Delete(Order order);
    }
}
