using Business.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using System.Linq;
using EntityLayer.Concrete;

namespace Core2.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        IMessageService _messageService;

        public MessageList(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _messageService.TGetList().OrderByDescending(x => x.Date).Take(3).ToList();
            return View(values);
        }
    }
}
