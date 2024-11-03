using asp.net_laboratorna11_shchedrov.Models;
using asp.net_laboratorna11_shchedrov.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace asp.net_laboratorna11_shchedrov.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ServiceFilter(typeof(ActionLoggingFilter))]
        [ServiceFilter(typeof(UniqueUserCountFilter))]
        public IActionResult Index()
        {
            return View();
        }
        [ServiceFilter(typeof(ActionLoggingFilter))]
        [ServiceFilter(typeof(UniqueUserCountFilter))]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
