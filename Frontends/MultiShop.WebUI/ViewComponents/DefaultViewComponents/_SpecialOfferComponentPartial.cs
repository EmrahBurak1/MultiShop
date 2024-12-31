using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOffersDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferService _specialOffer;

        public _SpecialOfferComponentPartial(ISpecialOfferService specialOffer)
        {
            _specialOffer = specialOffer;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _specialOffer.GetAllSpecialOfferAsync();
            return View(values);
        }
    }
}
