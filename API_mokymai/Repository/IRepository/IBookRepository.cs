using API_mokymai.Models;

namespace API_mokymai.Repository.IRepository
{
    public interface IBookRepository: IRepository<Book>
    {
        Task<Book> UpdateAsync(Book book);
        Task<bool> ExistAsync(int id);


    }
}
