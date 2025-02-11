﻿namespace Core.Entities.Concrete
{
    public class UserRefreshToken 
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}
