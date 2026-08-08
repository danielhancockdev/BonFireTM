using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Boards
{
    public class BoardSummary
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
