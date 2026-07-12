using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
