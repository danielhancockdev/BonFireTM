namespace Bonfire.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public string Email { get; set; }  = string.Empty;
    public string PasswordHash { get; set; }

    public DateTime CreatedAt { get; set; }

    // Navigation Properties

    public ICollection<Project> Projects { get; set; } = new List<Project>();

    public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

}