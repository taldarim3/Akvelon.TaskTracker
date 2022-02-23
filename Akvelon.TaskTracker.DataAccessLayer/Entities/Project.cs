using System.Collections;
using Akvelon.TaskTracker.DataAccessLayer.Enums;

namespace Akvelon.TaskTracker.DataAccessLayer.Entities;

/// <summary>
/// This class defines the entity of Project
/// </summary>
public class Project
{
    public Project()
    {
        Tasks = new List<ProjectTask>();
    }
    
    public int Id { get; set; }
    public List<ProjectTask> Tasks { get; set; }

    public string Name { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime ComplitionDate { get; set; }
    
    public ProjectStatus Status { get; set; }

    public int Priority { get; set; }
}