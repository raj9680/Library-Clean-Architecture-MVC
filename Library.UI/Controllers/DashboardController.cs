using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dashboard = await _dashboardService.GetDashboardInfoAsync();
            return View(dashboard);
        }
    }
}
