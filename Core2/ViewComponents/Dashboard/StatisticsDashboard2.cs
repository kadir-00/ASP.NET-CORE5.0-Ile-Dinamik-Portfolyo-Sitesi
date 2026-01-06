using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Concrete;
using System.Linq;

namespace Core2.ViewComponents.Dashboard
{
    public class StatisticsDashboard2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            try
            {
                ViewBag.v1 = c.Portfolios.Count();
                ViewBag.v2 = c.Messages.Count();
                ViewBag.v3 = c.Services.Count();
            }
            catch
            {
                ViewBag.v1 = 0;
                ViewBag.v2 = 0;
                ViewBag.v3 = 0;
            }
            return View();
        }
    }
}
