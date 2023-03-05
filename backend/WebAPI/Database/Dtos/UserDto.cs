using System.ComponentModel.DataAnnotations;

namespace WebAPI.Database.Dtos;

public class UserDto
{
    [Key]
    public int Id { get; set; }
    
    public string Email { get; set; }
    
    public string Name { get; set; }
    
    public string Status { get; set; }
    
    public string Description { get; set; }
    
    public string? Skills { get; set; }
    
    public string Title { get; set; }
    
    public string? Role { get; set; }
    
    public string? Image { get; set; }
}