using Application.DaoInterfaces;
using Shared.Models;

namespace FileData.Daos;

public class UserFileDao : IUserDao
{
    private readonly FileContext context;
    
    public UserFileDao(FileContext context)
    {
        this.context = context;
    }
    
    public Task<User> CreateAsync(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }
}