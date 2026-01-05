using Business.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Core2.Controllers
{
    public class AnnoncoumentController : Controller
    {
        AnnoncoumentManager annoncoumentManager = new AnnoncoumentManager(new EfAnnoncoumentDal());

        public IActionResult Index()
        {
            var values = annoncoumentManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnoncoument()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnoncoument(Annoncoument annoncoument)
        {
            annoncoument.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            annoncoument.Status = "Yeni";
            annoncoumentManager.TAdd(annoncoument);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAnnoncoument(int id)
        {
            var values = annoncoumentManager.TGetById(id);
            annoncoumentManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAnnoncoument(int id)
        {
            var values = annoncoumentManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditAnnoncoument(Annoncoument annoncoument)
        {
            annoncoumentManager.TUpdate(annoncoument);
            return RedirectToAction("Index");
        }
    }
}
