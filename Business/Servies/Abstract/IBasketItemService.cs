using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Servies.Abstract
{
    public interface IBasketItemService
    {
        Task<BasketItem?> GetAsync(Expression<Func<BasketItem, bool>> predicate);
        Task<List<BasketItem>?> GetListAsync(Expression<Func<BasketItem, bool>>? predicate = null);
        BasketItem Add(BasketItem basketItem);
        BasketItem Update(BasketItem basketItem);
        BasketItem Delete(BasketItem basketItem);
    }
}
