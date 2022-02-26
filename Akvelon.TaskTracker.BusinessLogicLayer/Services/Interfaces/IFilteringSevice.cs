using Akvelon.TaskTracker.DataAccessLayer.Entities;
using Akvelon.TaskTracker.DataAccessLayer.Enums;

namespace Akvelon.TaskTracker.BusinessLogicLayer.Services.Interfaces;

public interface IFilteringSevice
{
    public IList<Project> FilteringByStartDateAfter(IList<Project> projects, DateTime dateAfter);
        
    public IList<Project> FilteringByEndDateBefore(IList<Project> projects, DateTime dateBefore);
        
    public IList<Project> FilteringCountOfTasksInRange(IList<Project> projects, int start, int end);

    public IList<Project> FilteringByProjectStatus(IList<Project> projects, ProjectStatus status);
}