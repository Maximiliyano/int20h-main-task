using WebAPI.Models;

namespace WebAPI.Database.Dtos;

public class UserNotificationDto : Notification
{
    public int UserId { get; set; }
}