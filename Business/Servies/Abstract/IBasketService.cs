using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Business.Servies.Abstract
{
    public interface IBasketService
    {
        Task<Basket?> GetAsync(Expression<Func<Basket, bool>> predicate, Func<IQueryable<Basket>, IIncludableQueryable<Basket, object>>? include = null);
        Task<List<Basket>?> GetListAsync(Expression<Func<Basket, bool>>? predicate = null, Func<IQueryable<Basket>, IIncludableQueryable<Basket, object>>? include = null);
        Basket Add(Basket basket);
        Basket Update(Basket basket);
        Basket Delete(Basket basket);


    }
}
