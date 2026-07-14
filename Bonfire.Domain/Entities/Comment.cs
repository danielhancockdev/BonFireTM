namespace Bonfire.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }

    public string Content { get; set; } = string.Empty;     

    public DateTime CreatedAt { get; set; }

    // Foreign Keys

    public Guid UserId { get; set; }

    public Guid TaskItemId { get; set; }

    // Navigation Properties

    public User? User { get; set; }

    public TaskItem? TaskItem { get; set; }

}