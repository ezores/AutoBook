using System.Collections;

namespace UstamOgretiyorBize.Models;

public class Author:BaseModel
{
    
    public string FullName { get; set; }

    public ICollection<Book> Books { get; set; }
}