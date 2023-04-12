using Shared.Dtos;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<Post> CreateAsync(PostCreationDto dto);
    
    Task<ICollection<Post>> GetAsync(
        string? owner, 
        string? title
    );

    Task<PostCreationDto> GetPostByIdAsync(int id);
}