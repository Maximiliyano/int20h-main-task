using System.ComponentModel.DataAnnotations;

namespace WebAPI.Database.Dtos;

public class UserResumeDto
{
    public int Id { get; set; }
    
    [Key]
    public int UserId { get; set; }
}