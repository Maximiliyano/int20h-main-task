using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Database.Dtos;
using WebAPI.Models;
using WebAPI.Services.Base;

namespace WebAPI.Services;

public class NotificationService : BaseService
{
    public NotificationService(WebApiDbContext context) : base(context) { }

    public async Task<Notification> CreateNotification(Notification notification)
    {
        var notificationDto = _mapper.Map<UserNotificationDto>(notification);
        
        await _context.UserNotifications.AddAsync(notificationDto);
        await _context.SaveChangesAsync();

        return notification;
    }

    public async Task<bool> DeleteNotification(int notificationId)
    {
        var notification = await _context.UserNotifications.FirstOrDefaultAsync(x => x.Id == notificationId);

        if (notification is null)
        {
            return false;
        }
        
        _context.UserNotifications.Remove(notification);
        await _context.SaveChangesAsync();
        return true;
    }
}