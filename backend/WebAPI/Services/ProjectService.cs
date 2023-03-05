using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Database.Dtos;
using WebAPI.Models;
using WebAPI.Services.Base;

namespace WebAPI.Services;

public class ProjectService : BaseService
{
    public ProjectService(WebApiDbContext context) : base(context) { }
    
    public async Task<ProjectDto> CreateProject(ProjectDto project)
    {
        await _context.ProjectDtos.AddAsync(project);
        await _context.SaveChangesAsync();

        project.Id = _context.ProjectDtos.FirstOrDefaultAsync(x => x.Name == project.Name).Id;
        return project;
    }

    public async Task<IEnumerable<Project>> GetAllProjects()
    {
        var projectDtos = await _context.ProjectDtos.ToListAsync();
        
        var data = _mapper.Map<List<Project>>(projectDtos);

        return data;
    }
    
    public async Task<ProjectDto?> GetByIdProject(int id)
    {
        return await _context.ProjectDtos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Project> UpdateProject(ProjectDto project)
    {
        var data = await _context.ProjectDtos.FirstOrDefaultAsync(x => x.Id == project.Id);

        data.Description = project.Description;
        data.Name = project.Name;
        data.Capacity = project.Capacity;
        data.Rating = project.Rating;
        data.Members = project.Members;
        data.Steck = project.Steck;
        data.EndDate = project.EndDate;
        data.ProjectState = project.ProjectState;
        data.StartDate = project.StartDate;

        var mapped = _mapper.Map<Project>(data);
        return mapped;
    }
    
    public async Task<bool> Delete(int projectId)
    {
        var project = await _context.ProjectDtos.FirstOrDefaultAsync(u => u.Id == projectId);

        if (project == null)
        {
            return false;
        }

        _context.ProjectDtos.Remove(project);
        await _context.SaveChangesAsync();
        
        return true;
    }
}