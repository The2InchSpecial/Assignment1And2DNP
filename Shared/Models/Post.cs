namespace Shared.Models;

public class Post
{
    public string Title { get; private set; }
    public string Body { get; private set; }
    public string Owner { get; private set; }
    public int Id { get; set; }

    public Post(string title, string body, string owner)
    {
        Title = title;
        Body = body;
        Owner = owner;
    }
    
    private Post(){}
}