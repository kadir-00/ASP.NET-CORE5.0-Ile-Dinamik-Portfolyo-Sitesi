using Business.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core2.Controllers
{
    public class ToDoListController : Controller
    {
        ToDoListManager toDoListManager = new ToDoListManager(new EFToDoListDal());

        public IActionResult Index()
        {
            var values = toDoListManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddToDoList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToDoList(ToDoList toDoList)
        {
            toDoList.Status = false;
            toDoListManager.TAdd(toDoList);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteToDoList(int id)
        {
            var values = toDoListManager.TGetById(id);
            toDoListManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditToDoList(int id)
        {
            var values = toDoListManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditToDoList(ToDoList toDoList)
        {
            toDoListManager.TUpdate(toDoList);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id)
        {
            var value = toDoListManager.TGetById(id);
            if (value.Status)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            toDoListManager.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
