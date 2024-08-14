using BooksAPI.Model;
using Microsoft.EntityFrameworkCore;
namespace BooksAPI.DLL
{
    public class BookStoreDBContext: DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options) { }

        public  DbSet<Books> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BookDescription> BookDescription { get; set; }
           
        
    }
}
