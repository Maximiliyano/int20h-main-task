namespace WebAPI.Models;

public sealed class User
{
    public int Id { get; set; }
    
    public string Email { get; set; }
    
    public string Image { get; set; }
    
    public string Name { get; set; }
    
    public string Status { get; set; }
    
    public string? Role { get; set; }
    
    public string Description { get; set; }
    
    public string[] Skills { get; set; }
    
    public string Title { get; set; }

    public IEnumerable<Achievement>? Achievements { get; set; }
    
    public IEnumerable<int>? ProjectIds { get; set; }
    
    public Resume? Resume { get; set; }
}