using System;
using System.Collections.Generic;
using System.Text;
using Bonfire.Domain.Enums;

namespace Bonfire.Application.DTOs.TaskItems
{
    public class UpdateTaskItemDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public Guid? AssignedUserId { get; set; }
        public TaskPriority Priority { get; set; }
    }
}
