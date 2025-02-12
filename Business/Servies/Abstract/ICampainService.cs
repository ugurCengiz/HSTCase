using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Servies.Abstract
{
    public interface ICampainService
    {
        Task<Campaing?> GetAsync(Expression<Func<Campaing, bool>> predicate);
        Task<List<Campaing>?> GetListAsync(Expression<Func<Campaing, bool>>? predicate = null);
        Campaing Add(Campaing campaing);
        Campaing Update(Campaing campaing);
        Campaing Delete(Campaing campaing);
    }
}
