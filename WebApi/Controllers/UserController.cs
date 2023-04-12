using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController :ControllerBase
{
    private readonly IUserLogic UserLogic;

    public UserController(IUserLogic userLogic)
    {
        UserLogic = userLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<User>> CreateAsync(UserCreationDto dto)
    {
        try
        {
            User user = await UserLogic.CreateAsync(dto);
            return Created($"/User/{user.Username}", user);//changed from users
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    /*public async Task<bool> ValidateLogin(UserCreationDto dto)
    {
        bool result = await UserLogic.ValidateLogin(dto);
        return result;
    }*/
}
