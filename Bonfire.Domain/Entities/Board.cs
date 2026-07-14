namespace Bonfire.Domain.Entities;

public class Board
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    // Foreign Keys

    public Guid ProjectId { get; set; }

    // Navigation Properties

    public Project Project { get; set; } = null!;

    public ICollection<Column> Columns { get; set; } = new List<Column>();
}