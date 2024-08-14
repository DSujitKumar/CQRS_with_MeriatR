using BooksAPI.DLL;
using BooksAPI.Interfaces;
using BooksAPI.Model;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace BooksAPI.BLLServices
{
    
    public class AddRecordsService : AddRecords
    {
        private readonly BookStoreDBContext _bookStoreDBContext;
        public AddRecordsService(BookStoreDBContext bookStoreDBContext)
        {
            this._bookStoreDBContext = bookStoreDBContext;
        }

        public bool AddAllBookDetails()
        {
            using (StreamReader file = new StreamReader("./JsonData/Data.json"))
            {
                string json = file.ReadToEnd();

                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                List<BooksWhole> booksWhole = JsonConvert.DeserializeObject<List<BooksWhole>>(json, serializerSettings);



                foreach (BooksWhole bookdtl in booksWhole)
                {
                    Books books1 = new Books();

                    books1.title = bookdtl.title;
                    _bookStoreDBContext.Books.Add(books1);

                    Author author1 = new Author();
                    author1.BookId = bookdtl.id;
                    author1.author = bookdtl.author;
                    _bookStoreDBContext.Author.Add(author1);

                    BookDescription bookDescription1 = new BookDescription();
                    bookDescription1.imageLink = bookdtl.imageLink;
                    bookDescription1.pages = bookdtl.pages;
                    bookDescription1.country = bookdtl.country;
                    bookDescription1.year = bookdtl.year;
                    bookDescription1.language = bookdtl.language;
                    bookDescription1.link = bookdtl.link;
                    bookDescription1.BookId = bookdtl.id;

                    _bookStoreDBContext.BookDescription.Add(bookDescription1);
                }
                _bookStoreDBContext.SaveChanges();


            }
            return true;
        }

        public async Task<CommandResponseModel> createBookInstance(CommandRequestModel bookdtl)
        {
            Books books1 = new Books();

            books1.title = bookdtl.title;
            var id= _bookStoreDBContext.Books.Add(books1);
            _bookStoreDBContext.SaveChanges();
            var books2 = _bookStoreDBContext.Books.Where(a=>a.title.Equals(bookdtl.title)).FirstOrDefault();
            Author author1 = new Author();
            author1.BookId = books2.id;
            author1.author = bookdtl.author;
            _bookStoreDBContext.Author.Add(author1);

            BookDescription bookDescription1 = new BookDescription();
            bookDescription1.imageLink = bookdtl.imageLink;
            bookDescription1.pages = bookdtl.pages;
            bookDescription1.country = bookdtl.country;
            bookDescription1.year = bookdtl.year;
            bookDescription1.language = bookdtl.language;
            bookDescription1.link = bookdtl.link;
            bookDescription1.BookId = books2.id;

            _bookStoreDBContext.BookDescription.Add(bookDescription1);
            CommandResponseModel commandResponseModel = new CommandResponseModel() {
                id = books2.id
            };
            _bookStoreDBContext.SaveChanges();
            return commandResponseModel;
        }
    }
}
