using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API_mokymai.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly BookContext _db;

        public PersonRepository(BookContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _db.Persons.AnyAsync(x => x.Id == id);
        }

        public async Task<Person> UpdateAsync(Person person)
        {
            _db.Persons.Update(person);
            await _db.SaveChangesAsync();

            return person;
        }
    }
}
