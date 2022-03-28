using KapsamliProje.Ui.Extension;
using KapsamliProje.Ui.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KapsamliProje.Ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string role=" ";

        public HomeController(ILogger<HomeController>logger)  
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            UpdateSession();

            
            if (role=="Admin")
            {
              return  RedirectToAction("Admin","Admin"); //Admin controller (2.admin)ındaki Admin (1.admin) e git
            }
            

            else return View();
        }

        private void UpdateSession()
        {
            role = HttpContext.Session.Get<string>("Role");
            ViewBag.UserName = HttpContext.Session.Get<string>("UserName");
        }

        public IActionResult Privacy()
           

        {
            UpdateSession();
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}