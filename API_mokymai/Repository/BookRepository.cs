using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Repository.IRepository;

namespace API_mokymai.Repository
{
    public class BookRepository: Repository<Book>, IBookRepository
    {
        private readonly BookContext _db;

        public BookRepository(BookContext db) : base(db)
        {
            _db = db;
        }

        public bool Exist(int id)
        {
            return _db.Books.Any(x => x.Id == id);
        }

        public Book Update(Book book)
        {
            _db.Books.Update(book);
            _db.SaveChanges();

            return book;
        }
    }
}
