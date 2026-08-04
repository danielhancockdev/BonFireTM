using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string DisplayName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
