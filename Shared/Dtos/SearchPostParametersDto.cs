namespace Shared.Dtos;

public class SearchPostParametersDto
{
    public string? Owner { get; set; }
    public string? Title { get; set; }

    public SearchPostParametersDto(string? owner, string? title)
    {
        Owner = owner;
        Title = title;
    }
}