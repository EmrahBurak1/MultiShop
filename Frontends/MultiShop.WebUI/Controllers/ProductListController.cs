using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.x = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.ImageUrl = "test";
            createCommentDto.Rating = 1;
            createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createCommentDto.Status = false;
            createCommentDto.ProductId = "6713fc7eb85ddae648219b6b";
            var client = _httpClientFactory.CreateClient(); //Parametre olarak alınan değeri değişkene atadık.
            var jsonData = JsonConvert.SerializeObject(createCommentDto); //Json formatına çevirdik.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //Json formatındaki veriyi content olarak atadık. İkinci parametre hangi dil desteğinde olduğu. Üçüncü parametre ise mediatype'ın ne olduğunu belirtir. 
            var responseMessage = await client.PostAsync("https://localhost:7143/api/Comments", stringContent); //İlgili adrese istekte bulunabilmek için responseMessage değişkenine atadık.
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
