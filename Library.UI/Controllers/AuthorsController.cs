using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class AuthorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AddAuthor()
        {
            return View();
        }

        public IActionResult EditAuthor()
        {
            return View();
        }

        public IActionResult DeleteAuthor()
        {
            return RedirectToAction("Index");
        }
    }
}
