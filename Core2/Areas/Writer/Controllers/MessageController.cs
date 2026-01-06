using Business.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Writer")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writerMessageManager.GetListReceiverMessage(p);
            return View(messageList);
        }

        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writerMessageManager.GetListSenderMessage(p);
            return View(messageList);
        }

        public IActionResult MessageDetails(int id)
        {
            var values = writerMessageManager.TGetById(id);
            return View(values);
        }

        public async Task<IActionResult> ReceiverMessageDetails(int id)
        {
            var values = writerMessageManager.TGetById(id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            var values = _userManager.Users.ToList();
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            values = values.Where(x => x.Email != currentUser.Email).ToList();

            List<SelectListItem> recipients = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.Name + " " + x.Surname,
                                                   Value = x.Email
                                               }).ToList();
            ViewBag.Recipients = recipients;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string sender = values.Email;
            string senderName = values.Name + " " + values.Surname;

            p.Sender = sender;
            p.SenderName = senderName;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;

            writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessage");
        }
    }
}
