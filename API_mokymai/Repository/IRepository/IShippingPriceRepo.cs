﻿using API_mokymai.Models;

namespace API_mokymai.Repository.IRepository
{
    public interface IShippingPriceRepo: IRepository<AdditinionalShippingPrice>
    {
        Task<AdditinionalShippingPrice> UpdateAsync(AdditinionalShippingPrice price);

    }
}