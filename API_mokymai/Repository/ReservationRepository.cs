using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Repository.IRepository;

namespace API_mokymai.Repository
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly BookContext _db;

        public ReservationRepository(BookContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Reservation> UpdateAsync(Reservation res)
        {
            _db.Reservations.Update(res);
            await _db.SaveChangesAsync();

            return res;
        }
    }
}
