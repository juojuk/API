namespace API_mokymai.Models.ApiModels
{
    //copy -> Paste Special -> Paste JSON as Classes
    public class BookApiModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int pageCount { get; set; }
        public string excerpt { get; set; }
        public DateTime publishDate { get; set; }
    }

}
