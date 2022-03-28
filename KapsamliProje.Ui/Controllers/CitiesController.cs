using KapsamliProje.Ent;
using KapsamliProje.Uow;
using Microsoft.AspNetCore.Mvc;

namespace KapsamliProje.Ui.Controllers
{
    public class CitiesController : Controller
    {
        IUnitOfWork _unitOfWork;
        Cities _cities;
        public CitiesController(IUnitOfWork Uow)
        {
            _unitOfWork = Uow;
        }


        public IActionResult List()
        {
            return View(_unitOfWork._citiesRepos.GetCitiesLists());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        
        
        [HttpPost]
        public IActionResult Create(Cities model)
        {
            _unitOfWork._citiesRepos.Create(model);
            _unitOfWork.Save();
            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Edit()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Edit(Cities model)
        {
            _unitOfWork._citiesRepos.Update(model);
            _unitOfWork.Save();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Delete(Cities model)
        {
            _unitOfWork._citiesRepos.Delete(model);
            _unitOfWork.Save();
            return RedirectToAction("List");
        }




    }
}
