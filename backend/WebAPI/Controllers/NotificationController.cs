using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/notification")]
public class NotificationController : GlobalApiController
{
    private NotificationService _notificationService;
    
    public NotificationController(NotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost("new")]
    public async Task<IActionResult> Create(Notification notification)
    {
        return Ok(await _notificationService.CreateNotification(notification));
    }

    [HttpDelete]
    [Route("notificationId")]
    public async Task<IActionResult> Delete(int notificationId)
    {
        return Ok(await _notificationService.DeleteNotification(notificationId));
    }
}