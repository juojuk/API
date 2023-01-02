using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Repository.IRepository;

namespace API_mokymai.Repository
{
    public class ShippingPriceRepo : Repository<AdditinionalShippingPrice>, IShippingPriceRepo
    {
        private readonly BookContext _db;
        public ShippingPriceRepo(BookContext db) : base(db)
        {
            _db = db;
        }

        public async Task<AdditinionalShippingPrice> UpdateAsync(AdditinionalShippingPrice price)
        {
            _db.AdditinionalShippingPrices.Update(price);
            await _db.SaveChangesAsync();

            return price;
        }
    }
}
