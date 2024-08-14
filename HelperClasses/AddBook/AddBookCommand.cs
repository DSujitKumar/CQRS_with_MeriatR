using MediatR;

namespace BooksAPI.HelperClasses.AddBook
{
    public record AddBookCommand(string title, int pages, int year, string country, string imageLink, string language, string link, string author) : IRequest<int>;
    
}
