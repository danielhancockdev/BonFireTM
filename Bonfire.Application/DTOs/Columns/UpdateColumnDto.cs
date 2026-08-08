using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Columns
{
    public class UpdateColumnDto
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
