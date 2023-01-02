using API_mokymai.Data;
using API_mokymai.Models;
using API_mokymai.Repository.IRepository;

namespace API_mokymai.Repository
{
    public class ShippingOrderRepository : Repository<ShippingOrder>, IShippingOrderRepository
    {
        private readonly BookContext _db;

        public ShippingOrderRepository(BookContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ShippingOrder> UpdateAsync(ShippingOrder order)
        {
            _db.ShippingOrders.Update(order);
            await _db.SaveChangesAsync();

            return order;
        }
    }
}
