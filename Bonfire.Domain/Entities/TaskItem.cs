namespace Bonfire.Domain.Entities;

public class  TaskItem
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public GuidId ColumnId { get; set; }

    public GuidId AssignedUserId { get; set; }
}