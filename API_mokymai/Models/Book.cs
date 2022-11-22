using API_mokymai.Data;

namespace API_mokymai.Models
{
    public class Book
    {
        public Book()
        {
        }

        public Book(int id, string title, string author, ECoverType cover, int publishYear)
        {
            Id = id;
            Title = title;
            Author = author;
            Cover = cover;
            PublishYear = publishYear;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public ECoverType Cover { get; set; }
        public int PublishYear { get; set; }
    }
}