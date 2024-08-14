using BooksAPI.Model;

namespace BooksAPI.Interfaces
{
    public interface AddRecords
    {
        public Task<CommandResponseModel> createBookInstance(CommandRequestModel requestModel);
        public bool AddAllBookDetails();
    }
}
