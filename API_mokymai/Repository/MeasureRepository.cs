using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Repository.IRepository;

namespace API_mokymai.Repository
{
    public class MeasureRepository : Repository<Measure>, IMeasureRepository
    {
        private readonly BookContext _db;
        public MeasureRepository(BookContext db) : base(db)
        {
            _db = db;
        }
    }
}
