using Akvelon.TaskTracker.BusinessLogicLayer.Exceptions;
using Akvelon.TaskTracker.BusinessLogicLayer.Services.Interfaces;
using Akvelon.TaskTracker.DataAccessLayer.DataContext;
using Akvelon.TaskTracker.DataAccessLayer.Entities;
using Akvelon.TaskTracker.DataAccessLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace Akvelon.TaskTracker.BusinessLogicLayer.Services.Implementations;

public class ProjectTaskService : IProjectTaskService
{
    private readonly TaskTrackerDbContext _context;

    public ProjectTaskService(TaskTrackerDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateProjectTask(string name, string description, int priority, int projectId,
        CancellationToken cancellationToken, ProjectTaskStatus status = ProjectTaskStatus.ToDo)
    {
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId, cancellationToken);
        if (project == null)
        {
            throw new NotFoundException($"Project with id = {projectId} not found");
        }

        var task = new ProjectTask()
        {
            Name = name,
            Description = description,
            Priority = priority,
            Status = status,
            ProjectId = projectId
        };

        project.Tasks.Add(task);

        await _context.Tasks.AddAsync(task, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return task.Id;
    }

    public async Task<ProjectTask> GetTaskById(int id, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        if (task == null)
        {
            throw new NotFoundException($"Task with id = {id} not found");
        }

        return task;
    }

    public async Task<IList<ProjectTask>> GetAllTasks(CancellationToken cancellationToken)
    {
        var tasks = await _context.Tasks.ToListAsync(cancellationToken);
        if (!tasks.Any())
        {
            throw new NotFoundException("There are no tasks");
        }

        return tasks;
    }

    public async Task<IList<ProjectTask>> GetTasksByProject(int projectId, CancellationToken cancellationToken)
    {
        var project = await _context.Projects.Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.Id == projectId, cancellationToken);
        if (project == null)
        {
            throw new NotFoundException($"Project with id = {projectId} not found");
        }

        var tasks = project.Tasks.ToList();
        if (!tasks.Any())
        {
            throw new NotFoundException("There are no tasks in this project");
        }

        return tasks;
    }

    public async Task DeleteTask(int id, CancellationToken cancellationToken)
    {
        var task = await GetTaskById(id, cancellationToken);
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task EditProjectTask(int id, string name, string description, int priority, int projectId,
        CancellationToken cancellationToken, ProjectTaskStatus status)
    {
        var task = await GetTaskById(id, cancellationToken);
        task.Name = name;
        task.Description = description;
        task.Priority = priority;
        task.Status = status;
        
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId, cancellationToken);
        if (project != null)
        {
            task.ProjectId = project.Id;

        }
        else throw new NotFoundException($"Project with id = {projectId} not found");

        await _context.SaveChangesAsync(cancellationToken);
    }
}