using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Images.Controllers
{
    //NOT: Images microservice'ini yapmadım. Google Cloud Storage kullanılıyor.
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleDriveImageUploadController : ControllerBase
    {
    }
}
