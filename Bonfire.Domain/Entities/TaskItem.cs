using Bonfire.Domain.Enums;

namespace Bonfire.Domain.Entities;

public class  TaskItem
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid ColumnId { get; set; }

    public Column column { get; set; }

    public Guid? AssignedUserId { get; set; }

    public User? user { get; set; }

    public TaskPriority Priority { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime CreatedAt { get; set; }

}