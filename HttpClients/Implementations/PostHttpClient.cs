using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        Console.WriteLine("in the posthttpclient class");
        HttpResponseMessage response = await client.PostAsJsonAsync("/Post", dto);//changed from /users
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }

    public async Task<ICollection<Post>> GetAsync(string? owner, string? title)
    {
        HttpResponseMessage response = await client.GetAsync("/Post");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public async Task<PostCreationDto> GetPostByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/SpecificPost/{id}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
        PostCreationDto post = JsonSerializer.Deserialize<PostCreationDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }
}