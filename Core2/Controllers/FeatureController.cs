using Business.Concrete;
using Business.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        public IActionResult Index()
        {
            var values = featureManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFeature(Feature feature)
        {
            featureManager.TAdd(feature);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFeature(int id)
        {
            var values = featureManager.TGetById(id);
            featureManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditFeature(int id)
        {
            var values = featureManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditFeature(Feature feature)
        {
            featureManager.TUpdate(feature);
            return RedirectToAction("Index");
        }
    }
}
