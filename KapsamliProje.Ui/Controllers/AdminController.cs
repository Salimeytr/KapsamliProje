using Microsoft.AspNetCore.Mvc;

namespace KapsamliProje.Ui.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin() //methodu admin yapıyoruz
        {
            return View();
        }

    }
}
