using KapsamliProje.Ent;
using KapsamliProje.Uow;
using Microsoft.AspNetCore.Mvc;

    

namespace KapsamliProje.Ui.Controllers
{
    public class ProductsController : Controller
    {
        IUnitOfWork _uw;
        Products _products;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _uw =unitOfWork;

        }
        public IActionResult List()
        {
            UpdateSession();
            return View(_uw._productsRepos.GetProductsLists());
        }

        private void UpdateSession()
        {
            
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Products model)
        {
            _uw._productsRepos.Create(model);
            _uw.Save();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Edi(Products model)
        {
            _uw._productsRepos.Update(model);
            _uw.Save();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Delete(Products model)
        {
            _uw._productsRepos.Create(model);
            _uw.Save();
            return RedirectToAction("List");
        }
    }
}
