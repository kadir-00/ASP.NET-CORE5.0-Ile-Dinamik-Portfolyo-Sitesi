using Business.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core2.ViewComponents.Experience
{
    public class ExperienceList : ViewComponent
    {
        ExperinceManager experinceManager = new ExperinceManager(new EfExperienceDal());

        public IViewComponentResult Invoke()
        {
            var values = experinceManager.TGetList();
            return View(values);
        }
    }
}
