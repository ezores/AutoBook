using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace UstamOgretiyorBize.Models;
[Index(nameof(Name),nameof(AuthorId),IsUnique = true)] //book and author composite indexed -> same name and author can't be 
public class Book:BaseModel
{
    //public int Id { get; set; }
    public string Name { get; set; }
    public int PageSize { get; set; }
    [JsonIgnore]
    public int AuthorId { get; set; }
    [JsonIgnore]
    public Author Author { get; set; }
}
