using Application.Logic;
using Application.LogicInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostLogic PostLogic;

    public PostController(IPostLogic postLogic)
    {
        PostLogic = postLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(PostCreationDto dto)
    {
        try
        {
            Post post = await PostLogic.CreateAsync(dto);
            return Created($"/Post/{post.Owner}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync([FromQuery] string? owner, [FromQuery] string? title)
    {
        try
        {
            SearchPostParametersDto parameters = new(owner, title);
            var posts = await PostLogic.GetAsync(parameters);
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet, Route("/SpecificPost/{id:int}")]
    public async Task<ActionResult<Post>> GetPostByIdAsync([FromRoute] int id)
    {
        try
        {
            Post post = await PostLogic.GetPostByIdAsync(id);
            return Ok(post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}