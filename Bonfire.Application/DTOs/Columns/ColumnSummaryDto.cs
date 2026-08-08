using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Columns
{
    public class ColumnSummary
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
    }
}
