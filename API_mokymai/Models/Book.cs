using API_mokymai.Data;
using System.ComponentModel.DataAnnotations;

namespace API_mokymai.Models
{
    public class Book
    {
        public Book()
        {
        }

        public Book(int id, string title, string author, ECoverType cover, int publishYear, int quantity)
        {
            Id = id;
            Title = title;
            Author = author;
            Cover = cover;
            PublishYear = publishYear;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public ECoverType Cover { get; set; }
        public int PublishYear { get; set; }
        public int Quantity { get; set; } = 0;
    }
}