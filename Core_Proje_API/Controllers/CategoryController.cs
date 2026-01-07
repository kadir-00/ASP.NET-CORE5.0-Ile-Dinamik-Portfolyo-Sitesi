using Core_Proje_API.DAL.ApiContext;
using Core_Proje_API.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            var c = new Context();
            return Ok(c.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            using var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return CreatedAtAction(nameof(CategoryGet), new { id = p.CategoryID }, p);
        }

        [HttpDelete("{id}")]
        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            c.Remove(value);
            c.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public IActionResult CategoryUpdate(Category p)
        {
            using var c = new Context();
            var value = c.Categories.Find(p.CategoryID);
            if (value == null)
            {
                return NotFound();
            }
            value.CategoryName = p.CategoryName;
            c.Update(value);
            c.SaveChanges();
            return NoContent();
        }
    }
}
