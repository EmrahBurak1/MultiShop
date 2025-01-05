﻿using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public interface IDiscountServices
    {
        Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
    }
}
