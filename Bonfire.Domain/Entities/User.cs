namespace Bonfire.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public ICollection<TaskItem> AssignedTasks { get; set; } = new List<TaskItem>();

}