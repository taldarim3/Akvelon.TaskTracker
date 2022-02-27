using Akvelon.TaskTracker.BusinessLogicLayer.Exceptions;
using Akvelon.TaskTracker.BusinessLogicLayer.Services.Interfaces;
using Akvelon.TaskTracker.DataAccessLayer.DataContext;
using Akvelon.TaskTracker.DataAccessLayer.Entities;
using Akvelon.TaskTracker.DataAccessLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace Akvelon.TaskTracker.BusinessLogicLayer.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly TaskTrackerDbContext _context;

    public ProjectService(TaskTrackerDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateProject(string name, DateTime startDate, DateTime complitionDate,
        CancellationToken cancellationToken,
        ProjectStatus status = ProjectStatus.NotStarted, int priority = 1)
    {
        if (startDate > complitionDate)
        {
            throw new InvalidDateTimeException("The start date cannot be later than the end date");
        }

        var project = new Project
        {
            Name = name,
            StartDate = startDate,
            ComplitionDate = complitionDate,
            Priority = priority,
            Status = status
        };

        await _context.Projects.AddAsync(project, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return project.Id;
    }

    public async Task<Project> GetProjectById(int id, CancellationToken cancellationToken)
    {
        var project = await _context.Projects.Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (project == null)
        {
            throw new NotFoundException($"Project with id = {id} not found");
        }

        return project;
    }


    public async Task<IList<Project>> GetAllProjects(CancellationToken cancellationToken)
    {
        var projects = await _context.Projects.Include(p => p.Tasks).ToListAsync(cancellationToken);
        if (!projects.Any())
        {
            throw new NotFoundException("Projects not found");
        }

        return projects;
    }


    public async Task DeleteProject(int id, CancellationToken cancellationToken)
    {
        var project = await GetProjectById(id, cancellationToken);
        _context.Projects.Remove(project);
        await _context.SaveChangesAsync(cancellationToken);
    }


    public async Task EditProject(int projectId, string name, DateTime startDate, DateTime endDate,
        ProjectStatus status, int priority,
        CancellationToken cancellationToken)
    {
        if (startDate > endDate)
            throw new InvalidDateTimeException("The start date cannot be later than the end date");
        var project = await GetProjectById(projectId, cancellationToken);

        project.Name = name;
        project.StartDate = startDate;
        project.ComplitionDate = endDate;
        project.Status = status;
        project.Priority = priority;

        await _context.SaveChangesAsync(cancellationToken);
    }
}