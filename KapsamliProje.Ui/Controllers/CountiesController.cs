using KapsamliProje.Ent;
using KapsamliProje.Uow;
using Microsoft.AspNetCore.Mvc;

namespace KapsamliProje.Ui.Controllers
{
    public class CountiesController : Controller
    {
        IUnitOfWork _unitOfWork;
        Counties _counties;
        public CountiesController(IUnitOfWork Uow )
        {
            _unitOfWork=Uow;
        }

        public IActionResult List()
        {
            return View(_unitOfWork._countiesRepos.GetCountiesLists());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Counties model)
        {
            _unitOfWork._countiesRepos.Create(model);
            _unitOfWork.Save();
            return RedirectToAction("List");

        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Counties model)
        {
            _unitOfWork._countiesRepos.Update(model);
            _unitOfWork.Save();
            return RedirectToAction("List");
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Counties model)
        {
            _unitOfWork._countiesRepos.Delete(model);
            _unitOfWork.Save();
            return RedirectToAction("List");
        }

    }
}
