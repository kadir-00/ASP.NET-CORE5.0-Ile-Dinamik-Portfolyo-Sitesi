using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Core2.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser > _userManager;

        public DashboardController(UserManager<WriterUser> userManager )
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1=values.Name+" "+values.Surname;

            // Weather API
            string api = "62742af205bd75de1224191d9d16ae79";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=antalya&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document=XDocument.Load(connection);
            ViewBag.v6=document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            //statistics
            Context c = new Context();
            ViewBag.v2 = 0;
            ViewBag.v3 = c.Annoncouments.Count();
            ViewBag.v4 = 0 ;
            ViewBag.v5 = c.Skills.Count() ;
            return View();
        }
    }
}
