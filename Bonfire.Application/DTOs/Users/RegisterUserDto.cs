using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Users
{
    public class RegisterUserDto
    {
        public string DisplayName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
