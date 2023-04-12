using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        /*User? user = await userDao.GetByUsernameAsync(dto.Owner);
        if (user == null)
        {
            throw new Exception($"User with username {dto.Owner} was not found.");
        }*/

        ValidatePost(dto);
        Post post = new Post(dto.Title, dto.Body, dto.Owner);
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        return postDao.GetAsync(searchParameters);
    }

    public async Task<Post> GetPostByIdAsync(int id)
    {
        Post? post = await postDao.GetByIdAsync(id);
        if (post == null)
        {
            throw new Exception($"Post with id {id} not found");
        }

        return post;
    }

    private void ValidatePost(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) 
            throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(dto.Body))
            throw new Exception("Content of post cannot be empty");
        if (string.IsNullOrEmpty(dto.Owner))
            throw new Exception("post cannot exist without an owner");
    }
}