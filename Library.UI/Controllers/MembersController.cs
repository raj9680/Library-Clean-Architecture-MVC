using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMember()
        {
            return View();
        }

        public IActionResult EditMember()
        {
            return View();
        }

        public IActionResult DeleteMember()
        {
            return RedirectToAction("Index");
        }
    }
}
