using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trvaversal.Models;

namespace Trvaversal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogWarning("Index Sayfası Çağırldı");
            return View();
        }

        public IActionResult Test()
        {
            _logger.LogWarning("Test Sayfası Çağırldı");
            return View();
        }
    }
}
