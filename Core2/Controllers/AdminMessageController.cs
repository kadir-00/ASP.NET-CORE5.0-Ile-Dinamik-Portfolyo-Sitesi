using Business.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Core2.Controllers
{
    public class AdminMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        public IActionResult Index()
        {
            var values = messageManager.TGetList().OrderByDescending(x => x.MessageID).ToList();
            return View(values);
        }

        public IActionResult DeleteMessage(int id)
        {
            var values = messageManager.TGetById(id);
            messageManager.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id)
        {
            var value = messageManager.TGetById(id);
            if (value.Status)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            messageManager.TUpdate(value);
            return RedirectToAction("Index");
        }

        public IActionResult AdminMessageDetails(int id)
        {
            var values = messageManager.TGetById(id);
            return View(values);
        }
    }
}
