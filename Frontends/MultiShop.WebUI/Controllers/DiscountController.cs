using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountServices _discountServices;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountServices discountServices, IBasketService basketService)
        {
            _discountServices = discountServices;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult ConfirmDiscountCoupon(string code)
        {
            var values = _discountServices.GetDiscountCode(code);
            return View(values);
        }
    }
}
