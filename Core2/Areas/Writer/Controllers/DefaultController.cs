using Business.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core2.Areas.Writer.Controllers
{
    [Authorize] // artik buraya giris yapmamis kisiler erisemiyecek
    [Area("Writer")]
    public class DefaultController : Controller
    {
        AnnoncoumentManager annoncoumentManager = new AnnoncoumentManager(new EfAnnoncoumentDal());
        public IActionResult Index()
        {
            var values = annoncoumentManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AnnoncoumentDetails(int id)
        {
            Annoncoument annoncoument = annoncoumentManager.TGetById(id);
            return View(annoncoument);

        }
    }
}
