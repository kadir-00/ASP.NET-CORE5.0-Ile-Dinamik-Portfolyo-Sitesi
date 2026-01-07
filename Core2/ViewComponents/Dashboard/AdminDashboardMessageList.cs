using Business.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core2.ViewComponents.Dashboard
{
    public class AdminDashboardMessageList : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            var values = messageManager.TGetList().OrderByDescending(x => x.Date).Take(3).ToList();
            return View(values);
        }
    }
}
