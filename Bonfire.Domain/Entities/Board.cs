namespace Bonfire.Domain.Entities;

public class Board
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public Guid ProjectId { get; set; }
}