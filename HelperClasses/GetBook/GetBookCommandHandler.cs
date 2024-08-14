using BooksAPI.DLL;
using BooksAPI.Model;
using MediatR;

namespace BooksAPI.HelperClasses.GetBook
{
    public class GetBookCommandHandler : IRequestHandler<GetBookCommand, List<QueryResponseModel>>
    {
        private readonly BookStoreDBContext _bookStoreDBContext;
        public GetBookCommandHandler(BookStoreDBContext bookStoreDBContext)
        {
            this._bookStoreDBContext = bookStoreDBContext;
        }
        public async Task<List<QueryResponseModel>> Handle(GetBookCommand request, CancellationToken cancellationToken)
        {
            List<QueryResponseModel> lst = new List<QueryResponseModel>();

            if (request.id == 0)
            {
                BookDescription bookDescriptions = new BookDescription();
                Author author = new Author();

                Books book = _bookStoreDBContext.Books.Where(b => b.title == request.title).ToList().FirstOrDefault();
                if (book != null)
                {
                    bookDescriptions = _bookStoreDBContext.BookDescription.Where(a => a.BookId == book.id).ToList().FirstOrDefault();
                }
                if (book != null)
                {
                    author = _bookStoreDBContext.Author.Where(a => a.BookId == book.id).ToList().FirstOrDefault();
                }

                QueryResponseModel queryResponseModel = new QueryResponseModel()
                {
                    id = book.id,
                    title = book.title,
                    author = author.author,
                    country = bookDescriptions.country,
                    language = bookDescriptions.language,
                    link = bookDescriptions.link,
                    pages = bookDescriptions.pages,
                    year = bookDescriptions.year,
                };
                lst.Add(queryResponseModel);
                return lst;
            }
            else
            {
                BookDescription bookDescriptions = new BookDescription();
                Author author = new Author();

                Books book = _bookStoreDBContext.Books.Where(b => b.id == request.id).ToList().FirstOrDefault();
                if (book != null)
                {
                    bookDescriptions = _bookStoreDBContext.BookDescription.Where(a => a.BookId == book.id).ToList().FirstOrDefault();
                }
                if (book != null)
                {
                    author = _bookStoreDBContext.Author.Where(a => a.BookId == book.id).ToList().FirstOrDefault();
                }
                if (book != null)
                {
                    QueryResponseModel queryResponseModel = new QueryResponseModel()
                    {
                        id = book.id,
                        title = book.title,
                        author = author.author,
                        country = bookDescriptions.country,
                        language = bookDescriptions.language,
                        link = bookDescriptions.link,
                        pages = bookDescriptions.pages,
                        year = bookDescriptions.year,
                    };
                    lst.Add(queryResponseModel);
                    return lst;
                }
                return null;
            }
        }
    }
}
