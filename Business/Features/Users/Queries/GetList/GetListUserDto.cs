using Core.Entities.Concrete;

namespace Business.Features.Users.Queries.GetList
{
   public class GetListUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
    }
}
