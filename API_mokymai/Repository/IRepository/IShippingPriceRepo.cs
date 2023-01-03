using API_mokymai.Models;

namespace API_mokymai.Repository.IRepository
{
    public interface IShippingPriceRepo: IRepository<AdditionalShippingPrice>
    {
        Task<AdditionalShippingPrice> UpdateAsync(AdditionalShippingPrice price);

    }
}