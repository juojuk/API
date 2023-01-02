using API_mokymai.Models;

namespace API_mokymai.Repository.IRepository
{
    public interface IShippingOrderRepository : IRepository<ShippingOrder>
    {
        Task<ShippingOrder> UpdateAsync(ShippingOrder order);
    }
}
