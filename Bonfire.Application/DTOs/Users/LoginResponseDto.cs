using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Users
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}
