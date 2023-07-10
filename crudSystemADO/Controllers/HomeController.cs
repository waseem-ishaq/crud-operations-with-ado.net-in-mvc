using crudSystemADO.Models;
using GoogleAuthentication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace crudSystemADO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public ActionResult index() {
        //    var clientId = "879646337964-j858qui0vjq2mjsaqvbddjp2t43o0orp.apps.googleusercontent.com";
        //    var url = "http://localhost:5088/LoginController/GoogleLoginAuth";
        //    var response = GoogleAuth.GetAuthUrl(clientId, url);
        //    ViewBag.response = response;
        //    return View();
        //}

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

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