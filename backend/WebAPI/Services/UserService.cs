using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Database.Dtos;
using WebAPI.Models;
using WebAPI.Services.Base;

namespace WebAPI.Services;

public class UserService : BaseService
{
    public UserService(WebApiDbContext context) : base(context) { }

    public async Task<UserDto> CreateUser(UserDto user)
    {
        await _context.UserDtos.AddAsync(user);
        await _context.SaveChangesAsync();

        user.Id = _context.UserDtos.FirstOrDefaultAsync(x => x.Email == user.Email).Id;
        return user;
    }
    
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        var userDtos = await _context.UserDtos.ToListAsync();

        var data = _mapper.Map<List<User>>(userDtos);

        return data;
    }
    
    public async Task<UserDto?> GetUserById(int id)
    {
        return await _context.UserDtos.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<UserDto?> GetUserByEmail(string email)
    {
        return await _context.UserDtos.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User> UpdateUser(User user)
    {
        var data = await _context.UserDtos.FirstOrDefaultAsync(x => x.Id == user.Id);

        data.Description = user.Description;
        data.Email = user.Email;
        data.Name = user.Name;
        data.Skills = user.Skills.ToString();
        data.Image = user.Image;
        data.Role = user.Role;
        data.Status = user.Status;
        data.Title = user.Title;

        var mapped = _mapper.Map<User>(data);
        return mapped;
    }
    
    public async Task<bool> Delete(int userId)
    {
        var user = await _context.UserDtos.FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        _context.UserDtos.Remove(user);
        await _context.SaveChangesAsync();
        
        return true;
    }
}