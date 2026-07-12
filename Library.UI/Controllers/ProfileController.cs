using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
