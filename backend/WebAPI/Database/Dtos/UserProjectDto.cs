using System.ComponentModel.DataAnnotations;

namespace WebAPI.Database.Dtos;

public class UserProjectDto
{
    public int Id { get; set; }
    
    [Key]
    public int UserId { get; set; }
    
    public int ProjectId { get; set; }
    
    public string Role { get; set; }
    
    public string StartDate { get; set; }
    
    public string? EndDate { get; set; }
}