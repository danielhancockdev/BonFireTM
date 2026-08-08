using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Boards
{
    public class CreateBoardDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ProjectId { get; set; }
    }
}
