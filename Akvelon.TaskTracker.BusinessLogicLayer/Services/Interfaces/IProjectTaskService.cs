using Akvelon.TaskTracker.DataAccessLayer.Entities;
using Akvelon.TaskTracker.DataAccessLayer.Enums;

namespace Akvelon.TaskTracker.BusinessLogicLayer.Services.Interfaces;

public interface IProjectTaskService
{
    public Task<int> CreateProjectTask(string name, string description, int priority, int projectId,
        CancellationToken cancellationToken, ProjectTaskStatus status = ProjectTaskStatus.ToDo);


    public Task<ProjectTask> GetTaskById(int id, CancellationToken cancellationToken);


    public Task<IList<ProjectTask>> GetAllTasks(CancellationToken cancellationToken);


    public Task<IList<ProjectTask>> GetTasksByProject(int projectId, CancellationToken cancellationToken);


    public Task DeleteTask(int id, CancellationToken cancellationToken);


    public Task EditProjectTask(int id, string name, string description, int priority, int projectId,
        CancellationToken cancellationToken, ProjectTaskStatus status);
}