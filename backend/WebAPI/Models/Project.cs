using WebAPI.Enums;

namespace WebAPI.Models;

public sealed class Project
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public ProjectState ProjectState { get; set; }
    
    public IEnumerable<User> Members { get; set; }
    
    public IEnumerable<string> Steck { get; set; }

    public int Capacity { get; set; }
    
    public double Rating { get; set; }
    
    public string StartDate { get; set; }
    
    public string? EndDate { get; set; }
}