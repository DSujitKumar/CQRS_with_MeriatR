using BooksAPI.HelperClasses.AddBook;
using BooksAPI.HelperClasses.GetBook;
using BooksAPI.Interfaces;
using BooksAPI.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BooksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly FetchRecord _fetchRecord;
        private readonly AddRecords _AddRecords;
        public BookController(ISender sender, FetchRecord fetchRecord, AddRecords AddRecords) { _sender = sender; _fetchRecord = fetchRecord; _AddRecords = AddRecords; }

        [HttpPost("AddBooksMediatR")]
        public async Task<ActionResult<int>> AddBooksMediatR( AddBookCommand addBookCommand)
        {
            var details = await _sender.Send(addBookCommand);
            return Ok(details);
        }

        [HttpGet("BooksMediatR")]
        public async Task<ActionResult<List<QueryResponseModel>>> getBookDetailsMediatR([FromQuery] string? title, int id)
        {
            GetBookCommand query = new GetBookCommand(title, id);
           
            var details = await _sender.Send(query);
            return Ok(details);
        }
        [HttpGet("Books")]
        public IActionResult getBookDetails([FromQuery] string? title, int id)
        {
            QueryRequestModel query = new QueryRequestModel()
            {
                id = id,
                title = title
            };

            var details = _fetchRecord.getBook(query);
            return Ok(details);
        }

        [HttpGet("addAllBooks")]
        public IActionResult addBooks()
        {
           
            var details = _AddRecords.AddAllBookDetails();
            return Ok("Book Details added to Database");
        }
        [HttpPost("addBooks")]
        public IActionResult addBooksInstance(CommandRequestModel commandRequestModel)
        {
           
            var details = _AddRecords.createBookInstance(commandRequestModel);
            return Ok(JsonConvert.SerializeObject( details));
        }
    }
}
