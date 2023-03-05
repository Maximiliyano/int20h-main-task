using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Base;
using WebAPI.Database.Dtos;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : GlobalApiController
{
    private readonly UserService _userService;
    
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDto user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        return Ok(await _userService.CreateUser(user));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userService.GetAllUsers());
    }
    
    
    [HttpGet]
    [Route("{userId:int}")]
    public async Task<IActionResult> GetById([FromRoute] int userId)
    {
        var data = await _userService.GetUserById(userId);

        if (data is null)
        {
            return NotFound();
        }
        
        return Ok(data);
    }
    
    [HttpGet]
    [Route("{email}")]
    public async Task<IActionResult> GetByEmail([FromRoute] string email)
    {
        var data = await _userService.GetUserByEmail(email);

        if (data is null)
        {
            return NotFound();
        }
        
        return Ok(data);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] User userData)
    {
        var user = await _userService.UpdateUser(userData);
        return user != null 
            ? Ok(user) 
            : NotFound();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int userId)
    {
        var state = await _userService.Delete(userId);
        return state ? Ok() : NotFound();
    }
}