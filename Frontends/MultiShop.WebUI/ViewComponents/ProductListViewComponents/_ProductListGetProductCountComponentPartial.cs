using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListGetProductCountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(int productCount)
        {
            return View(productCount);
        }
    }
}
