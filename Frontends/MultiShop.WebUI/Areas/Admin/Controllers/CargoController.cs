using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class CargoController : Controller
    {
        public IActionResult CargoList()
        {
            return View();
        }
    }
}
