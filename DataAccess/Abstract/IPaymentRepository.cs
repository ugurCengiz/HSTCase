using Core.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPaymentRepository: IEntityRepository<Payment>
    {
    }
}
