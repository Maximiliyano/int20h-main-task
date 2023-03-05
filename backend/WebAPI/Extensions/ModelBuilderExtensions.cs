using Microsoft.EntityFrameworkCore;
using WebAPI.Database.Dtos;
using WebAPI.Helpers;

namespace WebAPI.Extensions;

public static class ModelBuilderExtensions
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDto>()
            .HasOne(u => u.Email)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }

    public static void Seed(this ModelBuilder modelBuilder)
    {
        var users = GenerateRandomUsers(10);
        var projects = GenerateRandomProjects(10);

        modelBuilder.Entity<UserDto>().HasData(users);
        modelBuilder.Entity<ProjectDto>().HasData(projects);
    }
    
    private static IEnumerable<UserDto> GenerateRandomUsers(int limit)
    {
        var users = new List<UserDto>();
        
        for (var i = 0; i < limit; i++)
        {
            users.Add(BuildUserDataDto(i));
        }
        return users;
    }

    private static IEnumerable<ProjectDto> GenerateRandomProjects(int limit)
    {
        var projects = new List<ProjectDto>();
        
        for (var i = 0; i < limit; i++)
        {
            projects.Add(BuildProjectDto(i));
        }
        return projects;
    } 
    
    private static ProjectDto BuildProjectDto(int id) =>
        new()
        {
            Id = id + 1,
            ProjectState = AppHelper.RandomProjectState().ToString(),
            Name = AppHelper.RandomizeCharacters(5),
            Members = AppHelper.RandomizeCharacters(5),
            Description = AppHelper.RandomizeCharacters(20),
            Steck = AppHelper.RandomizeCharacters(20),
            Capacity = AppHelper.RandomizeNumber(10, 30),
            Rating = AppHelper.RandomizeNumber(1, 10),
            StartDate = "5/03/2023",
            EndDate = "10/04/2024",
        };
    
    private static UserDto BuildUserDataDto(int id) =>
        new()
        {
            Id = id + 1,
            Email = AppHelper.RandomizeCharacters(7),
            Name = AppHelper.RandomizeCharacters(5),
            Status = AppHelper.RandomProjectState().ToString(),
            Description = AppHelper.RandomizeCharacters(20),
            Skills = AppHelper.RandomizeCharacters(20),
            Title = AppHelper.RandomizeCharacters(10)
        };
}