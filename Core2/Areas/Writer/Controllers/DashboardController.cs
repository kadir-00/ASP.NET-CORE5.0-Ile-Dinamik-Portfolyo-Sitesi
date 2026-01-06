using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core2.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = values.Name + " " + values.Surname;

            // Weather API
            string api = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=886705b4c1182eb1c69f28eb8c520e20";
            XDocument document = XDocument.Load(api);
            ViewBag.vWeather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            // Context for counts
            Context c = new Context();
            ViewBag.v2 = c.WriterMessages.Where(x => x.Receiver == values.Email).Count();
            ViewBag.v3 = c.Annoncouments.Count();
            ViewBag.v4 = c.Users.Count();
            ViewBag.v5 = c.Skills.Count();

            return View();
        }
    }
}
