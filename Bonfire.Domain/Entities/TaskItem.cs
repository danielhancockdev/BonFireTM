using Bonfire.Domain.Enums;

namespace Bonfire.Domain.Entities;

public class  TaskItem
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime? DueDate { get; set; }

    public DateTime CreatedAt { get; set; }

    // Foreign Keys

    public Guid ColumnId { get; set; }

    public Guid? AssignedUserId { get; set; }

    // Navigation Properties

    public User? AssignedUser { get; set; }

    public Column Column { get; set; }

    public TaskPriority Priority { get; set; }

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public ICollection<Label> Labels { get; set; } = new List<Label>();
}