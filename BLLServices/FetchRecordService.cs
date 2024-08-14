using BooksAPI.DLL;
using BooksAPI.Interfaces;
using BooksAPI.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.IO;

namespace BooksAPI.BLLServices
{
    public class FetchRecordService : FetchRecord
    {
        private readonly BookStoreDBContext _bookStoreDBContext;
        public FetchRecordService(BookStoreDBContext bookStoreDBContext)
        {
            this._bookStoreDBContext = bookStoreDBContext;
        }
        public List<QueryResponseModel> getBook(QueryRequestModel request)
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
