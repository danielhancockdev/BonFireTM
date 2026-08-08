using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Labels
{

    public class LabelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }
}
