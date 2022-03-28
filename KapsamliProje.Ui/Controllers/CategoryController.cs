using KapsamliProje.Ent;
using KapsamliProje.Uow;
using Microsoft.AspNetCore.Mvc;

namespace KapsamliProje.Ui.Controllers
{
    public class CategoryController : Controller
    {
        IUnitOfWork _uow;
        Categories _categories;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;

        }
        public IActionResult List()
        {
            return View(_uow._categoriesRepos.GetCategoriesLists());
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Categories model)
        {
            _uow._categoriesRepos.Create(model);
            _uow.Save();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Edit(Categories model)
        {
            _uow._categoriesRepos.Update(model);
            _uow.Save();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Delete(Categories model)
        {
            _uow._categoriesRepos.Create(model);
            _uow.Save();
            return RedirectToAction("List");
        }
    }
}

