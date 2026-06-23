using DevSkill.Shop.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DevSkill.Shop.Web.Controllers
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
            try
            {
                _logger.LogInformation("Home page accessed");
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Home Index");
                return View("Error");
            }
        }

        public IActionResult Privacy()
        {
            try
            {
                _logger.LogInformation("Privacy page accessed");
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Privacy page");
                return View("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            _logger.LogError("Error page accessed with ID: {ErrorId}", errorId);

            return View(new ErrorViewModel { RequestId = errorId });
        }
    }
}