using Akvelon.TaskTracker.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Akvelon.TaskTracker.DataAccessLayer.Entities.Task;

namespace Akvelon.TaskTracker.DataAccessLayer.DataContext;

public class TaskTrackerDbContext : DbContext
{
    public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options)
    {
    }

    public TaskTrackerDbContext()
    {
    }

    public DbSet<Task> Tasks { get; set; }
    public DbSet<Project> Projects { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=Jopa18102001");
    }
}

