using Book_list.Model;
using Microsoft.AspNetCore.Mvc;

namespace Book_list.Controllers
{
    [ApiController]
    [Route("api/Book")]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db) 
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {data = _db.Book.ToList()});
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var bookFromDb = _db.Book.FirstOrDefault(u => u.Id == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _db.Book.Remove(bookFromDb);
            _db.SaveChanges();
            return Json(new { success = true, message = "Delete successful" });

        }
    }
}
