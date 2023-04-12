namespace Shared.Dtos;

public class PostCreationDto
{
    public string Title { get;}
    public string Body { get;}
    public string Owner { get;}

    public PostCreationDto(string title, string body, string owner)
    {
        Title = title;
        Body = body;
        Owner = owner;
    }
}