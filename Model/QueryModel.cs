namespace BooksAPI.Model
{
    public class QueryRequestModel
    {
        public int id { get; set; }
        public string? title { get; set; }
    }
    public class QueryResponseModel
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string author { get; set; }
        public int pages { get; set; }
        public int year { get; set; }
        public string? country { get; set; }
        public string language { get; set; }
        public string link { get; set; }
    }
}
