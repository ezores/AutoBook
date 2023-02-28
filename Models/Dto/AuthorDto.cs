using System.ComponentModel.DataAnnotations;

namespace UstamOgretiyorBize.Models.Dto;

public class AuthorDto
{
    [StringLength(32,MinimumLength = 2)]
    public string FullName { get; set;}
    
}