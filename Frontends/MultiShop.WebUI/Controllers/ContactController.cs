using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.IsRead = false;
            createContactDto.SendDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient(); //Parametre olarak alınan değeri değişkene atadık.
            var jsonData = JsonConvert.SerializeObject(createContactDto); //Json formatına çevirdik.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //Json formatındaki veriyi content olarak atadık. İkinci parametre hangi dil desteğinde olduğu. Üçüncü parametre ise mediatype'ın ne olduğunu belirtir. 
            var responseMessage = await client.PostAsync("https://localhost:7070/api/Contacts", stringContent); //İlgili adrese istekte bulunabilmek için responseMessage değişkenine atadık.
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
