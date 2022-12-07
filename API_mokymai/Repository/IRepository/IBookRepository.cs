using API_mokymai.Models;

namespace API_mokymai.Repository.IRepository
{
    public interface IBookRepository: IRepository<Book>
    {
        Book Update(Book book);
        bool Exist(int id);
    }
}
