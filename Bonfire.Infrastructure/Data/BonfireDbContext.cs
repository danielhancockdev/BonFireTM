using Bonfire.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bonfire.Infrastructure.Data;

public class BonfireDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the relationships and constraints for the entities

       
        // Project has many Boards, Board has one Project
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Boards)
            .WithOne(b => b.Project)
            .HasForeignKey(b => b.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
       
        // Board has many Columns, Column has one Board
        modelBuilder.Entity<Board>()
            .HasMany(b => b.Columns)
            .WithOne(c => c.Board)
            .HasForeignKey(c => c.BoardId)
            .OnDelete(DeleteBehavior.Cascade);
       
        // Column has many TaskItems, TaskItem has one Column
        modelBuilder.Entity<Column>()
            .HasMany(c => c.TaskItems)
            .WithOne(t => t.Column)
            .HasForeignKey(t => t.ColumnId)
            .OnDelete(DeleteBehavior.Cascade);
       
        // TaskItem has many Comments, Comment has one TaskItem
        modelBuilder.Entity<TaskItem>()
            .HasMany(t => t.Comments)
            .WithOne(c => c.TaskItem)
            .HasForeignKey(c => c.TaskItemId)
            .OnDelete(DeleteBehavior.Cascade);

        // TaskItem has many Labels, Label has many TaskItems (many-to-many relationship)
        modelBuilder.Entity<TaskItem>()
            .HasMany(t  => t.Labels)
            .WithMany(l => l.TaskItems);

        // User has many Projects, Project has one User (Owner)
        modelBuilder.Entity<User>()
            .HasMany(u => u.Projects)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // User has many Comments, Comment has one User (Creator)
        modelBuilder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // User has many TaskItems, TaskItem has one User (Assigned)
        modelBuilder.Entity<User>()
            .HasMany(u => u.TaskItems)
            .WithOne(t => t.AssignedUser)
            .HasForeignKey(t => t.AssignedUserId)
            .OnDelete(DeleteBehavior.Restrict);       
    }

    public BonfireDbContext(DbContextOptions<BonfireDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Project> Projects => Set<Project>();

    public DbSet<Board> Boards => Set<Board>();

    public DbSet<Column> Columns => Set<Column>();

    public DbSet<TaskItem> TaskItems => Set<TaskItem>();

    public DbSet<Comment> Comments => Set<Comment>();

    public DbSet<Label> Labels => Set<Label>();
}