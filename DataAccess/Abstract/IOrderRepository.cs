using Core.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOrderRepository: IEntityRepository<Order>
    {
    }
}
