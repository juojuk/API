using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API_mokymai.Repository
{
    public class BookRepository: Repository<Book>, IBookRepository
    {
        private readonly BookContext _db;

        public BookRepository(BookContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _db.Books.AnyAsync(x => x.Id == id);
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            _db.Books.Update(book);
            await _db.SaveChangesAsync();

            return book;
        }
    }
}
