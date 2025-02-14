using Core.Entities.Concrete;

namespace Business.Features.Users.Commands.Update
{
  public  class UpdateUserResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public Status Status { get; set; }
    }
}
