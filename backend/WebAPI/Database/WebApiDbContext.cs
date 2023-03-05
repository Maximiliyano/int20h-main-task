using Microsoft.EntityFrameworkCore;
using WebAPI.Database.Dtos;
using WebAPI.Extensions;

namespace WebAPI.Database;

public class WebApiDbContext : DbContext
{
    public DbSet<UserDto> UserDtos { get; set; }
    public DbSet<ProjectDto> ProjectDtos { get; set; }

    public WebApiDbContext(DbContextOptions options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Configure();
        modelBuilder.Seed();
    }
}