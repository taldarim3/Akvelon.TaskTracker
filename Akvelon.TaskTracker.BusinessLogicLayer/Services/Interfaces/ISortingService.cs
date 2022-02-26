using Akvelon.TaskTracker.DataAccessLayer.Entities;

namespace Akvelon.TaskTracker.BusinessLogicLayer.Services.Interfaces;

public interface ISortingService
{
    public IList<Project> SortByStartDateDescending(IList<Project> projects);
        
    public IList<Project> SortByCompletionDateAscending(IList<Project> projects);
        
    public IList<Project> SortByPriorityDescending(IList<Project> projects);

    public IList<Project> SortByStatusAscending(IList<Project> projects);

}