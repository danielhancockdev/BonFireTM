using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.DTOs.Projects
{
    public class ProjectSummaryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
