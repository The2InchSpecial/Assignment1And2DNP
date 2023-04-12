using Application.DaoInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace FileData.Daos;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }
    
    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(t => t.Id);
            id++;
        }

        post.Id = id;
        
        Console.WriteLine("what is this");
        context.Posts.Add(post);
        Console.WriteLine("about to save");
        context.SaveChanges();
        Console.WriteLine("saved");
        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParams)
    {
        IEnumerable<Post> result = context.Posts.AsEnumerable();

        if (!string.IsNullOrEmpty(searchParams.Owner))
        {
            result = context.Posts.Where(post =>
                post.Owner.Equals(searchParams.Owner, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(searchParams.Title))
        {
            result = result.Where(t =>
                t.Title.Contains(searchParams.Title, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(result);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(u =>
            u.Id == id
        );
        return Task.FromResult(existing);
    }
}