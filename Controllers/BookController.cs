using Microsoft.AspNetCore.Mvc;
using UstamOgretiyorBize.DBu;
using UstamOgretiyorBize.Models;
using UstamOgretiyorBize.Models.Dto;

namespace UstamOgretiyorBize.Controllers;
[Route("/[controller]")]
public class BookController:ControllerBase
{
    private readonly AppDbContext _db;

    public BookController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public ActionResult<Book> CreateBook([FromBody] BookDto DtoBook)
    {
        var author = _db.Authors.FirstOrDefault(a => a.Id == DtoBook.AuthorId);
        //Console.WriteLine(author.Books.First().Name);

        if (null == author)
        {
            return NotFound();
        }
        var bookz = author.Books.FirstOrDefault(b => b.Name == DtoBook.Name);
        if (bookz != null)
        {
            return Conflict("senin anoni");
        }

        var book = new Book
        {
            Name = DtoBook.Name,
            PageSize = DtoBook.PageSize,
            AuthorId = DtoBook.AuthorId
            
        };
        
        _db.Books.Add(book);
        
        _db.SaveChanges();
        
        return book;
    }
}