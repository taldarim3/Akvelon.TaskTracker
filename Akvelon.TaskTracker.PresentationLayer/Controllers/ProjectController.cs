﻿using Akvelon.TaskTracker.BusinessLogicLayer.Services.Implementations;
using Akvelon.TaskTracker.DataAccessLayer.Entities;
using Akvelon.TaskTracker.DataAccessLayer.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Akvelon.TaskTracker.Controllers
{
    /// <summary>
    /// Controller with methods for projects
    /// </summary>
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _serviceProject;

        private readonly SortAndFilteringService _serviceSortAndFiltering;

        public ProjectController(ProjectService serviceProject, SortAndFilteringService serviceSortAndFiltering)
        {
            _serviceProject = serviceProject;
            _serviceSortAndFiltering = serviceSortAndFiltering;
        }

        // CRUD methods

        /// <summary>
        /// This method creates the project.
        /// </summary>
        /// <param name="name">Project name</param>
        /// <param name="startDate">Project start date</param>
        /// <param name="endDate">Project completion date</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="status">Project status</param>
        /// <param name="priority">Project priority</param>
        /// <returns>ID of the created project</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST: /localhost/projects
        /// 
        /// </remarks>
        /// <response code="200">Successfully created</response>
        /// <response code="400">If start date after completion date</response>
        [HttpPost("projects")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<int> CreateProject(string name, DateTime startDate, DateTime endDate,
            int priority, ProjectStatus status, CancellationToken cancellationToken)
        {
            return await _serviceProject.CreateProject(name, startDate, endDate, cancellationToken, status, priority);
        }

        /// <summary>
        /// This method gets project by their ID
        /// </summary>
        /// <param name="id">Project ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Project entity</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: /localhost/projects/{id}
        ///
        /// </remarks>
        /// <response code="200">Successfully received</response>
        /// <response code="404">If project not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/{id}")]
        public async Task<Project> GetProjectById(int id, CancellationToken cancellationToken)
        {
            return await _serviceProject.GetProjectById(id, cancellationToken);
        }

        /// <summary>
        /// This method gets all projects
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of Projects</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: /localhost/projects
        /// 
        /// </remarks>
        /// <response code="200">Successfully received</response>
        /// <response code="404">If project not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects")]
        public async Task<IList<Project>> GetAllProjects(CancellationToken cancellationToken)
        {
            return await _serviceProject.GetAllProjects(cancellationToken);
        }

        /// <summary>
        /// This method edits the project information
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="name">Project name</param>
        /// <param name="startDate">Project start date</param>
        /// <param name="endDate">Project completion date</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="status">Project status</param>
        /// <param name="priority">Project priority</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT: /localhost/projects
        ///
        /// </remarks>
        /// <response code="200">Successfully updated</response>
        /// <response code="404">If project not found</response>
        /// <response code="400">If start date after completion date</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("projects")]
        public async Task EditProject(int projectId, string name, DateTime startDate, DateTime endDate,
            ProjectStatus status, int priority, CancellationToken cancellationToken)
        {
            await _serviceProject.EditProject(projectId, name, startDate, endDate, status, priority,
                cancellationToken);
        }

        /// <summary>
        /// This method deletes the project
        /// </summary>
        /// <param name="id">Project ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE: /localhost/projects
        /// 
        /// </remarks>
        /// <response code="200">Successfully deleted</response>
        /// <response code="404">If project not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("projects")]
        public async Task DeleteProject(int id, CancellationToken cancellationToken)
        {
            await _serviceProject.DeleteProject(id, cancellationToken);
        }

        // Sorting methods

        /// <summary>
        /// This method sort the list of all projects by descending the start date.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of projects</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: localhost/projects/sort/startDate
        /// 
        /// </remarks>
        /// <response code="200">Successfully received</response>
        /// <response code="404">If project not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/sort/startDate")]
        public async Task<IList<Project>> SortByStartDateDescending(CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortAndFiltering.SortByStartDateDescending(projects);
        }

        /// <summary>
        /// This method sort the list of all projects by ascending the completion date.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of projects</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: localhost/projects/sort/endDate
        /// 
        /// </remarks>
        /// <response code="200">Successfully received</response>
        /// <response code="404">If project not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/sort/endDate")]
        public async Task<IList<Project>> SortByCompletionDateAscending(CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortAndFiltering.SortByCompletionDateAscending(projects);
        }

        /// <summary>
        /// This method sort the list of all projects by descending the priority value.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of projects</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: localhost/projects/sort/priority
        /// 
        /// </remarks>
        /// <response code="200">Successfully received</response>
        /// <response code="404">If project not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/sort/priority")]
        public async Task<IList<Project>> SortByPriorityDescending(CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortAndFiltering.SortByPriorityDescending(projects);
        }

        /// <summary>
        /// This method sort the list of all projects by ascending the status.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of projects</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: localhost/projects/sort/status
        /// 
        /// </remarks>
        /// <response code="200">Successfully received</response>
        /// <response code="404">If project not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/sort/status")]
        public async Task<IList<Project>> SortByStatusAscending(CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortAndFiltering.SortByStatusAscending(projects);
        }

        // Filtering methods

        /// <summary>
        /// This method filter the list of all projects by start date after the date stated 
        /// </summary>
        /// <param name="dateAfter">Date after must be found</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of projects</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: /localhost/projects/filter/startDate
        /// 
        /// </remarks>
        /// <response code="200">Successfully received</response>
        /// <response code="404">If project not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/filter/startDate")]
        public async Task<IList<Project>> FilteringByStartDateAfter(DateTime dateAfter,
            CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortAndFiltering.FilteringByStartDateAfter(projects, dateAfter);
        }

        /// <summary>
        /// This method filter the list of all projects by completion date before the date stated 
        /// </summary>
        /// <param name="dateBefore">Date before must be found</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of projects</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: /localhost/projects/filter/endDate
        /// 
        /// </remarks>
        /// <response code="200">Successfully received</response>
        /// <response code="404">If project not found</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/filter/endDate")]
        public async Task<IList<Project>> FilteringByEndDateBefore(DateTime dateBefore,
            CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortAndFiltering.FilteringByEndDateBefore(projects, dateBefore);
        }

        /// <summary>
        /// This method filter the list of all projects by contains tasks more than in range
        /// </summary>
        /// <param name="start">Start range value</param>
        /// <param name="end">End range value</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of projects</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: /localhost/projects/filter/countOfTasks
        /// 
        /// </remarks>
        /// <response code="200">Successfully received</response>
        /// <response code="404">If project not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/filter/countOfTasks")]
        public async Task<IList<Project>> FilteringCountOfTasksInRange(int start, int end,
            CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortAndFiltering.FilteringCountOfTasksInRange(projects, start, end);
        }

        /// <summary>
        /// This method filter the list of all projects by status
        /// </summary>
        /// <param name="status">Status</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of project</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: /localhost/projects/filter/status
        /// 
        /// </remarks>
        /// <response code="200">Successfully received</response>
        /// <response code="404">If project not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("projects/filter/status")]
        public async Task<IList<Project>> FilteringByProjectStatus(ProjectStatus status,
            CancellationToken cancellationToken)
        {
            var projects = await _serviceProject.GetAllProjects(cancellationToken);
            return _serviceSortAndFiltering.FilteringByProjectStatus(projects, status);
        }
    }
}
