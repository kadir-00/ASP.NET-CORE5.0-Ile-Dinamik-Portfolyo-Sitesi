using Business.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ToDoListController : Controller
    {
        ToDoListManager toDoListManager = new ToDoListManager(new EFToDoListDal());

        public IActionResult Index()
        {
            var values = toDoListManager.TGetList();
            return View(values);
        }
    }
}
