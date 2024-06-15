using Business.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core2.Controllers
{
    public class ExperienceController : Controller
    {
        ExperinceManager experinceManager = new ExperinceManager(new EfExperienceDal()); 
        public IActionResult Index()
        {
            var values = experinceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
             experinceManager.TAdd(experience);
            return RedirectToAction("Index");

        }

        public IActionResult DeleteExperience(int id)
        {
            var values = experinceManager.TGetById(id);
            experinceManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            ViewBag.v1 = "Duzenleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Duzenleme";
            var values = experinceManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experinceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }

    }
}
