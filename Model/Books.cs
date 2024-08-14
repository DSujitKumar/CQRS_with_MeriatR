using System.ComponentModel.DataAnnotations;

namespace BooksAPI.Model
{
    public class Books
    {
        public string title { get; set; }
        [Key]
        public int id { get; set; }
    }
}
