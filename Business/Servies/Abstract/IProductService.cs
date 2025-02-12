using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Servies.Abstract
{
   public interface IProductService
    {
        Task<Product?> GetAsync(Expression<Func<Product, bool>> predicate);
        Task<List<Product>?> GetListAsync(Expression<Func<Product, bool>>? predicate = null);
        Product Add(Product product);
        Product Update(Product product);
        Product Delete(Product product);
    }
}
