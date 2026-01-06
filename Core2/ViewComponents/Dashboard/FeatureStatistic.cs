using Business.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core2.ViewComponents.Dashboard
{
    public class FeatureStatistic : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            try
            {
                ViewBag.v1 = c.Skills.Count();
                ViewBag.v2 = c.Messages.Where(x => x.Status == false).Count();
                ViewBag.v3 = c.Messages.Where(x => x.Status == true).Count();
                ViewBag.v4 = c.Experionces.Count();
            }
            catch
            {
                ViewBag.v1 = 0;
                ViewBag.v2 = 0;
                ViewBag.v3 = 0;
                ViewBag.v4 = 0;
            }
            return View();
        }
    }


}
