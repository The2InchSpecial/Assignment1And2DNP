using Shared.Dtos;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);
    /*Task<bool> ValidateLogin(UserCreationDto user);*/
}