using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Users
{
    public class UserSummaryDto
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; } = string.Empty;
    }
}
