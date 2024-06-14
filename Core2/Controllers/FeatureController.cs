using Microsoft.AspNetCore.Mvc;

namespace Core2.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
