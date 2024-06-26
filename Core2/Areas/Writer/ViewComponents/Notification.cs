using Business.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core2.Areas.Writer.ViewComponents
{
    public class Notification : ViewComponent
    {
        AnnoncoumentManager annoncoumentManager = new AnnoncoumentManager(new EfAnnoncoumentDal());
        public IViewComponentResult Invoke()
        {
           
            var values = annoncoumentManager.TGetList().Take(5).ToList();
            return View();

        }
    }
}
