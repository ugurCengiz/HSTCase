using Core.Repositories;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class CampainRepository : EfEntityRepositoryBase<Campaing, AppDbContext>, ICampainRepository
    {
        public CampainRepository(AppDbContext context) : base(context)
        {
        }
    }
}
