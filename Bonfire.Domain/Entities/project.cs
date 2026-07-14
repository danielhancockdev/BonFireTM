namespace Bonfire.Domain.Entities;

public class Project
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    // Navigation Properties

    public ICollection<Board> Boards { get; set; } = new List<Board>();
}