using API_mokymai.Models;

namespace API_mokymai.Repository.IRepository
{
    public interface IReservationRepository: IRepository<Reservation>
    {
        Task<Reservation> UpdateAsync(Reservation res);
    }
}
