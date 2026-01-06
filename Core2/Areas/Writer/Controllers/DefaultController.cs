using Business.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Core2.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Writer")]
    public class DefaultController : Controller
    {
        AnnoncoumentManager annoncoumentManager = new AnnoncoumentManager(new EfAnnoncoumentDal());

        public IActionResult Index()
        {
            var values = annoncoumentManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(Annoncoument p)
        {
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Status = "Yeni";
            annoncoumentManager.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAnnouncement(int id)
        {
            var values = annoncoumentManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditAnnouncement(Annoncoument p)
        {
            annoncoumentManager.TUpdate(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var values = annoncoumentManager.TGetById(id);
            annoncoumentManager.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult AnnouncementDetails(int id)
        {
            var values = annoncoumentManager.TGetById(id);
            return View(values);
        }
    }
}
