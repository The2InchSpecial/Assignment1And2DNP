using Shared.Dtos;
using Shared.Models;

namespace WebApi.Services;

public interface IAuthService
{
    Task<User> GetUser(string username, string password);
    Task<User> RegisterUser(UserCreationDto dto);
    Task<User> ValidateUser(string username, string password);
}