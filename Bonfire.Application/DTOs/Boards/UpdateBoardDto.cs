using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Boards
{
    public class UpdateBoardDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
