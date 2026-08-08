using System;
using System.Collections.Generic;
using System.Text;
using Bonfire.Domain.Enums;

namespace Bonfire.Application.DTOs.TaskItems
{
    public class TaskItemSummary
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid? AssignedUserId { get; set; }
    }
}
