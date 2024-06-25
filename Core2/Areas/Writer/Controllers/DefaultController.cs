using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core2.Areas.Writer.Controllers
{
    public class DefaultController : Controller
    {
        [Authorize] // artik buraya giris yapmamis kisiler erisemiyecek
        [Area("Writer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
