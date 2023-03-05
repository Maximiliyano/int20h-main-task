using System.ComponentModel.DataAnnotations;

namespace WebAPI.Database.Dtos;

public class ProjectDto
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string ProjectState { get; set; }
    
    public string Members { get; set; }
    
    public string Steck { get; set; }

    public int Capacity { get; set; }
    
    public double Rating { get; set; }
    
    public string StartDate { get; set; }
    
    public string? EndDate { get; set; }
}