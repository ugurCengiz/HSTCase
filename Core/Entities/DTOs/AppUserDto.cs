﻿using Core.Entities.Concrete;

namespace Core.Entities.DTOs
{
    public class AppUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
    }
}
