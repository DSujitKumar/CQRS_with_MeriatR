using BooksAPI.DLL;
using BooksAPI.Model;
using MediatR;

namespace BooksAPI.HelperClasses.AddBook
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, int>
    {
        private readonly BookStoreDBContext _bookStoreDBContext;
        public AddBookHandler(BookStoreDBContext bookStoreDBContext)
        {
            this._bookStoreDBContext = bookStoreDBContext;
        }
        public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var books1 = new Books() { 
                title=request.title
            };

            _bookStoreDBContext.Books.Add(books1);
            await _bookStoreDBContext.SaveChangesAsync();

            Author author1 = new Author();
            author1.BookId = books1.id;
            author1.author = request.author;
            _bookStoreDBContext.Author.Add(author1);

            BookDescription bookDescription1 = new BookDescription();
            bookDescription1.imageLink = request.imageLink;
            bookDescription1.pages = request.pages;
            bookDescription1.country = request.country;
            bookDescription1.year = request.year;
            bookDescription1.language = request.language;
            bookDescription1.link = request.link;
            bookDescription1.BookId = books1.id;

            _bookStoreDBContext.BookDescription.Add(bookDescription1);
            await _bookStoreDBContext.SaveChangesAsync();
            return books1.id;
        }
    }
}
