namespace BooksAPI.Model
{
    public class CommandRequestModel
    {
        public string title { get; set; }
        public int pages { get; set; }
        public int year { get; set; }
        public string country { get; set; }
        public string imageLink { get; set; }
        public string language { get; set; }
        public string link { get; set; }
        public string author { get; set; }
    }
    public class CommandResponseModel
    {
        public int id { get; set; }
        public string? title { get; set; }
    }
}
