using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
