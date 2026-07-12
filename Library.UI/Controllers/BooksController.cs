using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBook()
        {
            return View();
        }

        public IActionResult EditBook()
        {
            return View();
        }

        public IActionResult IssueBook()
        {
            return View();
        }
        
        public IActionResult ReturnBook()
        {
            return View();
        }

        public IActionResult DeleteBook()
        {
            return RedirectToAction("Index");
        }
    }
}
