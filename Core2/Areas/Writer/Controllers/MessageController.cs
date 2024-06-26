using Microsoft.AspNetCore.Mvc;

namespace Core2.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MessageController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
