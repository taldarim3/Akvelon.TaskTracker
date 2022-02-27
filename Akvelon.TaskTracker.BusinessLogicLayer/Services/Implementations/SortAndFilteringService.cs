using Akvelon.TaskTracker.BusinessLogicLayer.Services.Interfaces;
using Akvelon.TaskTracker.DataAccessLayer.Entities;
using Akvelon.TaskTracker.DataAccessLayer.Enums;

namespace Akvelon.TaskTracker.BusinessLogicLayer.Services.Implementations;

public class SortAndFilteringService: IFilteringSevice, ISortingService
{
    public IList<Project> SortByStartDateDescending(IList<Project> projects)
    {
        return projects.OrderByDescending(p => p.StartDate).ToList();
    }

    public IList<Project> SortByCompletionDateAscending(IList<Project> projects)
    {
        return projects.OrderBy(p => p.ComplitionDate).ToList();
    }

    public IList<Project> SortByPriorityDescending(IList<Project> projects)
    {
        return projects.OrderByDescending(p => p.Priority).ToList();
    }

    public IList<Project> SortByStatusAscending(IList<Project> projects)
    {
        return projects.OrderBy(p => (int) p.Status).ToList();
    }

    public IList<Project> FilteringByStartDateAfter(IList<Project> projects, DateTime dateAfter)
    {
        return projects.Where(p => p.StartDate > dateAfter).ToList();
    }

    public IList<Project> FilteringByEndDateBefore(IList<Project> projects, DateTime dateBefore)
    {
        return projects.Where(p => p.ComplitionDate < dateBefore).ToList();
    }

    public IList<Project> FilteringCountOfTasksInRange(IList<Project> projects, int start, int end)
    {
        return projects.Where(p => p.Tasks.Count >= start && p.Tasks.Count <= end).ToList();
    }

    public IList<Project> FilteringByProjectStatus(IList<Project> projects, ProjectStatus status)
    {
        return projects.Where(p => p.Status == status).ToList();
    }
}