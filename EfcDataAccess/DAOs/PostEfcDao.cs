using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Dtos;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostContext context;

    public PostEfcDao(PostContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        IQueryable<Post> postsQuery = context.posts.AsQueryable();

        List<Post> result = await postsQuery.ToListAsync();
        return result;
    }

    public Task UpdateAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetByIdAsync(int postId)
    {

        Post? existing = context.posts.FirstOrDefault(u =>
            u.Id == postId
        );
        return Task.FromResult(existing);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}