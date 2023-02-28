using Microsoft.EntityFrameworkCore;
using UstamOgretiyorBize.Models;

namespace UstamOgretiyorBize.DBu;

public class AppDbContext:DbContext
{
    
    
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
    {
        
    }
    
    //Entity framework knows them now as tables
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}