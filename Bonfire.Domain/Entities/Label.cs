namespace Bonfire.Domain.Entities;

public class Label
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    // Navigation Properties

    public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
}