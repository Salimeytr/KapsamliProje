

using KapsamliProje.Ent;
using KapsamliProje.Repos.Abstract;
using KapsamliProje.Ui.Extension;
using KapsamliProje.Ui.Models.ViewModels;
using KapsamliProje.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KapsamliProje.Ui.Controllers
{
    public class AuthController : Controller
    {
        
        LoginModel _model;
        IUnitOfWork _unitOfWork;
        public const string Role = "Role";
        public const string UserName = "UserName"; 

        public AuthController(IUnitOfWork unitOfWork, LoginModel model)
        {
            _unitOfWork = unitOfWork;
            _model = model;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(_model);
        }
        [HttpPost] //Bunu koymak zorundayız.
        public IActionResult Register(LoginModel model)
        {
            _unitOfWork._authRepos.Register(model.UserId, model.Password);
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Login() //içerisine parametre yazmamıza gerek yok
        {
            return View("Register",_model);
        }
        [HttpPost] //Bunu koymak zorundayız.
        public IActionResult Login(LoginModel model) //Post kısmında parametrelere ihtiyacımız var
        {
            Users user =_unitOfWork._authRepos.Login(model.UserId, model.Password);
            if (user!=null)
            {
                HttpContext.Session.Set<string>(UserName,model.UserId);
                HttpContext.Session.Set<string>(Role, user.Role);
                var a=  HttpContext.Session.Get<string>(Role);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }

    }
}
