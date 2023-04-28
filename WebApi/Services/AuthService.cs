using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace WebApi.Services;

public class AuthService : IAuthService
{

    private readonly IUserDao users;
    private readonly IPostDao posts;

    public AuthService(IUserDao users, IPostDao posts)
    {
        this.users = users;
        this.posts = posts;
    }
    
    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = await users.GetByUsernameAsync(username);
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }

    public Task<User> GetUser(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<User> RegisterUser(UserCreationDto dto)
    {
        User? existing = await users.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");
        
        User user = new User
        {
            Username = dto.UserName,
            Password = dto.Password,
        };

        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }

        User created = await users.CreateAsync(user);
        
        return created;
    }
}