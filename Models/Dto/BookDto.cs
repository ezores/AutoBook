using System.ComponentModel.DataAnnotations;

namespace UstamOgretiyorBize.Models.Dto;

public class BookDto
{
    [StringLength(64,MinimumLength = 2)]
    public string Name { get; set; }
    [Range(8,1200)]
    public int PageSize { get; set; }
    [Range(0,Int32.MaxValue)]
    public int AuthorId { get; set; }
  
}