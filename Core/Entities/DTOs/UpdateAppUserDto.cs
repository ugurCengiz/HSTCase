using Core.Entities.Concrete;

namespace Core.Entities.DTOs
{
    public class UpdateAppUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public Status Status { get; set; }
    }
}
