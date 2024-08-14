using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BooksAPI.Model
{
    public class BookDescription
    {
        [ForeignKey("Books")]
        public int BookId { get; set; }
        [Key]
        public int Id { get; set; }
        public int pages { get; set; }
        public int year { get; set; }
        public string country { get; set; }
        public string imageLink { get; set; }
        public string language { get; set; }
        public string link { get; set; }
    }
}
