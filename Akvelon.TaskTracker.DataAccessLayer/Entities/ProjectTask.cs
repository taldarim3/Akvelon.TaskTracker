using Akvelon.TaskTracker.DataAccessLayer.Enums;

namespace Akvelon.TaskTracker.DataAccessLayer.Entities;

/// <summary>
/// This class defines the entity of Task
/// </summary>
public class ProjectTask
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public ProjectTaskStatus Status { get; set; }

    public int Priority { get; set; }
    
    public int ProjectId { get; set; }
        
    public Project Project { get; set; }
    
}