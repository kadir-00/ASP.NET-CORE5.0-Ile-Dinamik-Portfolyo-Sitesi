using Business.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core2.ViewComponents.Dashboard
{
    public class Last5Project : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
