using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        [Area("Admin")] //Area olduğunu bildirmemiz gerekiyor.
        public IActionResult Index()
        {
            return View();
        }
    }
}
