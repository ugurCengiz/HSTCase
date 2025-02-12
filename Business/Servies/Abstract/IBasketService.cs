using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Servies.Abstract
{
   public interface IBasketService
    {
        Task<Basket?> GetAsync(Expression<Func<Basket, bool>> predicate);
        Task<List<Basket>?> GetListAsync(Expression<Func<Basket, bool>>? predicate = null);
        Basket Add(Basket basket);
        Basket Update(Basket basket);
        Basket Delete(Basket basket);


    }
}
