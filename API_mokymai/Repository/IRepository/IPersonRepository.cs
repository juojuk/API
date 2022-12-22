using API_mokymai.Models;

namespace API_mokymai.Repository.IRepository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> UpdateAsync(Person person);
        Task<bool> ExistAsync(int id);

    }
}
