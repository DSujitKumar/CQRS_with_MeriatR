using BooksAPI.Model;
using MediatR;

namespace BooksAPI.HelperClasses.GetBook
{
    public record GetBookCommand(string? title,int id):IRequest<List<QueryResponseModel>>;
    
}
