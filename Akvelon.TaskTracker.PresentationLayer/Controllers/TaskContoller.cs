using Akvelon.TaskTracker.BusinessLogicLayer.Services.Implementations;
using Akvelon.TaskTracker.DataAccessLayer.Entities;
using Akvelon.TaskTracker.DataAccessLayer.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Akvelon.TaskTracker.Controllers;

public class TaskController : ControllerBase
{
    private readonly ProjectTaskService _service;

    public TaskController(ProjectTaskService service)
    {
        _service = service;
    }

    // CRUD methods

    /// <summary>
    /// This method creates a task.
    /// </summary>
    /// <param name="name">Task name</param>
    /// <param name="description">Task description</param>
    /// <param name="priority">Task priority</param>
    /// <param name="projectId">Project that contains this task</param>
    /// <param name="status">Task status</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task ID</returns>
    /// <summary>
    /// Sample request:
    ///
    ///     POST: /localhost/tasks
    /// 
    /// </summary>
    /// <response code="200">Successfully created</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("tasks")]
    public async Task<int> CreateTask(string name, string description, int priority, int projectId,
        ProjectTaskStatus status,
        CancellationToken cancellationToken)
    {
        return await _service.CreateProjectTask(name, description, priority, projectId, cancellationToken, status);
    }

    /// <summary>
    /// This method gets the all created tasks
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of all tasks</returns>
    /// <summary>
    /// Sample request:
    ///
    ///     GET: /localhost/tasks
    /// 
    /// </summary>
    /// <response code="200">Successfully received</response>
    /// <response code="404">If task not found</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("tasks")]
    public async Task<IList<ProjectTask>> GetAllTasks(CancellationToken cancellationToken)
    {
        return await _service.GetAllTasks(cancellationToken);
    }

    /// <summary>
    /// This method gets task by ID
    /// </summary>
    /// <param name="id">Task ID</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task entity</returns>
    /// <summary>
    /// Sample request:
    ///
    ///     GET: /localhost/tasks
    /// 
    /// </summary>
    /// <response code="200">Successfully received</response>
    /// <response code="404">If task not found</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("tasks")]
    public async Task<ProjectTask> GetTaskById(int id, CancellationToken cancellationToken)
    {
        return await _service.GetTaskById(id, cancellationToken);
    }

    /// <summary>
    /// This method gets all tasks in project
    /// </summary>
    /// <param name="projectId">Project ID</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of tasks</returns>
    /// <summary>
    /// Sample request:
    ///
    ///     GET: /localhost/project/tasks
    /// 
    /// </summary>
    /// <response code="200">Successfully received</response>
    /// <response code="404">If task not found</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("project/tasks")]
    public async Task<IList<ProjectTask>> GetTasksByProject(int projectId, CancellationToken cancellationToken)
    {
        return await _service.GetTasksByProject(projectId, cancellationToken);
    }

    /// <summary>
    /// This method edits the task information
    /// </summary>
    /// <param name="taskId">Task ID</param>
    /// <param name="name">Task name</param>
    /// <param name="description">Task description</param>
    /// <param name="priority">Task priority</param>
    /// <param name="projectId">Project that contains this task</param>
    /// <param name="status">Task status</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <summary>
    /// Sample request:
    ///
    ///     PUT: /localhost/tasks
    /// 
    /// </summary>
    /// <response code="200">Successfully updated</response>
    /// <response code="404">If task not found</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("tasks")]
    public async Task UpdateTask(int taskId, string name, string description, int projectId, int priority,
        ProjectTaskStatus status,
        CancellationToken cancellationToken)
    {
        await _service.EditProjectTask(taskId, name, description, priority, projectId, cancellationToken, status);
    }

    /// <summary>
    /// This method deletes task
    /// </summary>
    /// <param name="id">Task ID</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <summary>
    /// Sample request:
    ///
    ///     DELETE: /localhost/tasks
    /// 
    /// </summary>
    /// <response code="200">Successfully deleted</response>
    /// <response code="404">If task not found</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("tasks")]
    public async Task DeleteTask(int id, CancellationToken cancellationToken)
    {
        await _service.DeleteTask(id, cancellationToken);
    }
}