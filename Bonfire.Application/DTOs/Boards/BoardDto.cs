using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Boards
{
    public class BoardDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public Guid ProjectId { get; set; }
    }
}
