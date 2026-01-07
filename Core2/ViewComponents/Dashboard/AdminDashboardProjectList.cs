using Business.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core2.ViewComponents.Dashboard
{
    public class AdminDashboardProjectList : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList().OrderByDescending(x => x.PortfolioID).Take(5).ToList();
            return View(values);
        }
    }
}
