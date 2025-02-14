using Core.Entities.Concrete;

namespace HST.Case.Web.Models
{
    public class UpdateUserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
    }
}
