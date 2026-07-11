namespace Bonfire.Domain.Entities;

public class Column
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Position { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid BoardId { get; set; }

    public Board board { get; set; }

    public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
}