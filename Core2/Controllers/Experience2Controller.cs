using Business.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Core2.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperinceManager experinceManager = new ExperinceManager(new EfExperienceDal());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experinceManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            experinceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetById(int ExperienceID)
        {
            var v = experinceManager.TGetById(ExperienceID);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);
        }

        public IActionResult DeleteExperience(int id)
        {
            var v = experinceManager.TGetById(id);
            experinceManager.TDelete(v);
            return NoContent();
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience p)
        {
            var v = experinceManager.TGetById(p.ExperinceID);
            // Updating fields manually to ensure we don't lose data if partial update or just standard update practice
            // However, for simplicity here we rely on the object passed being full or we update the retrieved object
            // Better to update the retrieved object with new values
            v.Name = p.Name;
            v.Date = p.Date;
            v.ImageUrl = p.ImageUrl;
            v.Description = p.Description;
            experinceManager.TUpdate(v);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
    }
}
