using Akvelon.TaskTracker.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Akvelon.TaskTracker.DataAccessLayer.Entities.ProjectTask;

namespace Akvelon.TaskTracker.DataAccessLayer.DataContext;

public class TaskTrackerDbContext : DbContext
{
    public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options)
    {
    }

    public TaskTrackerDbContext()
    {
    }

    public DbSet<ProjectTask> Tasks { get; set; }
    public DbSet<Project> Projects { get; set; }
    
}

