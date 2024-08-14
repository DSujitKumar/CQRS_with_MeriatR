using BooksAPI.Model;

namespace BooksAPI.Interfaces
{
    public interface FetchRecord
    {
        public List<QueryResponseModel> getBook(QueryRequestModel request);
    }
}
