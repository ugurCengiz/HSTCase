using Core.Entities.Concrete;
using DataAccess.Abstract;
using Core.Repositories;
using DataAccess.Contexts;

namespace DataAccess.Concrete;

public class UserRefreshTokenRepository : EfEntityRepositoryBase<UserRefreshToken, AppDbContext>, IUserRefreshTokenRepository
{
    public UserRefreshTokenRepository(AppDbContext context) : base(context)
    {
    }
}
