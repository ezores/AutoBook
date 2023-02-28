using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UstamOgretiyorBize.DBu;
using UstamOgretiyorBize.Extensions;
using UstamOgretiyorBize.Models;
using UstamOgretiyorBize.Models.Dto;

namespace UstamOgretiyorBize.Controllers;
[Route("/[controller]")]
public class AuthorController:ControllerBase
{
    private readonly AppDbContext _db;

    public AuthorController(AppDbContext db)
    {
        _db = db;
    }
    
    [HttpPost]
    public ActionResult<Author> CreateAuthor([FromBody] AuthorDto DtoPayload)
    {
        var author = new Author
        {
            FullName = DtoPayload.FullName
        };
        
        _db.Authors.Add(author);
        _db.SaveChanges();
        
        return author;
    }

    [HttpGet]
    public ActionResult<ICollection<Author>> GetAuthors()
    {
        return Ok(_db.Authors.Include(a => a.Books).ToList());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Author> GetAuthor(int id)
    {
        return _db.Authors.FindOneOrThrow(id);
        //return null;
    }
}