using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Servies.Abstract
{
    public interface IOrderDetailService
    {
        Task<OrderDetail?> GetAsync(Expression<Func<OrderDetail, bool>> predicate);
        Task<List<OrderDetail>?> GetListAsync(Expression<Func<OrderDetail, bool>>? predicate = null);
        OrderDetail Add(OrderDetail orderDetail);
        OrderDetail Update(OrderDetail orderDetail);
        OrderDetail Delete(OrderDetail orderDetail);
    }
}
