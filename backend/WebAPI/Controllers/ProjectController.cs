using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;
using WebAPI.Database.Dtos;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/project")]
public class ProjectController : GlobalApiController
{
    private readonly ProjectService _projectService;
    
    public ProjectController(ProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProjectDto projectDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        return Ok(await _projectService.CreateProject(projectDto));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _projectService.GetAllProjects());
    }

    [HttpGet]
    [Route("{projectId:int}")]
    public async Task<IActionResult> GetById(int projectId)
    {
        var data = await _projectService.GetByIdProject(projectId);

        if (data is null)
        {
            return NotFound();
        }
        
        return Ok(data);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ProjectDto projectData)
    {
        var project = await _projectService.UpdateProject(projectData);
        return project != null 
            ? Ok(project) 
            : NotFound();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int projectId)
    {
        var state = await _projectService.Delete(projectId);
        return state ? Ok() : NotFound();
    }
}