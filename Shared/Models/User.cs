﻿using System.Text.Json.Serialization;

namespace Shared.Models;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public int Id { get; set; }
    [JsonIgnore]
    public ICollection<Post> posts { get; set; }
}