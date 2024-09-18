using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial: ViewComponent //Partial component kullanımı için ViewComponent sınıfından miras alınır.
    {
        public IViewComponentResult Invoke() //Invoke metodu ViewComponent sınıfından miras alınan metoddur.
        {
            return View(); //View() metodu ile ilgili view döndürülür.
        }
    }
}
