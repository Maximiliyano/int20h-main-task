using System.ComponentModel.DataAnnotations;

namespace WebAPI.Database.Dtos;

public class UserAchievementDto
{
    public int Id { get; set; }
    
    [Key]
    public int UserId { get; set; }
    
    public int AchievementId { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
}