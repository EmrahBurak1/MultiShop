using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountServices
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync($"Discounts/GetCodeDetailByCode/{code}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values;
        }
    }
}
