using Microsoft.AspNetCore.Mvc;

namespace Core2.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
