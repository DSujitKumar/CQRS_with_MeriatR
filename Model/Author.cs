using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAPI.Model
{
    public class Author
    {
        [ForeignKey("Books")]
        public int BookId { get; set; }
        [Key]
        public int Id { get; set; }
        public string author { get; set; }
    }
}
