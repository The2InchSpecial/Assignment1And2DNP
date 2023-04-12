namespace Shared.Models;

public class Post
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string Owner { get; set; }
    public int Id { get; set; }

    public Post(string title, string body, string owner)
    {
        Title = title;
        Body = body;
        Owner = owner;
    }
}