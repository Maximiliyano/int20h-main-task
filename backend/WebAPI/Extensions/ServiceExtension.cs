using WebAPI.Services;

namespace WebAPI.Extensions;

public static class ServiceExtension
{
    public static void RegisterCustomServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddScoped<ProjectService>();
        services.AddScoped<NotificationService>();
    }
}