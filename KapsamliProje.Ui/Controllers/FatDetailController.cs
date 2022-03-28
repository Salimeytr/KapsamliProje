using KapsamliProje.Ent;
using KapsamliProje.Ui.Models.ViewModels;
using KapsamliProje.Uow;
using Microsoft.AspNetCore.Mvc;

namespace KapsamliProje.Ui.Controllers
{
    public class FatDetailController : Controller
    {
        //Fatura detay kısmının yaratıldığını alışveriş sitesinde kullanıcı görmez.Ama admin görür hangi müşteri alım yapıyorsa bizim görmemizi sağlar.
        IUnitOfWork _unitOfWork;
        FatDetailModel _fatDetailModel;
        FatDetail _fatDetail;
        public FatDetailController(IUnitOfWork unitOfWork,FatDetailModel fatDetailModel,FatDetail fatDetail)
        {
            _unitOfWork = unitOfWork;//unitofwork den veri çekmek için bu kısmı aracı olarak yazıyoruz.
            _fatDetailModel = fatDetailModel;   //Fatdetail kısmından veri çekmek için bu kısmı aracı oalrak yazıyoruz
            _fatDetail=fatDetail;
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            var fm= _unitOfWork._fatMasterRepos.Find(id);//Faturayı ıd ile buluyoruz
            var cus= _unitOfWork._customersRepos.Find(fm.CustomerId);// Müşteri ıd sini fatura master dan çekiyoruz
           var emp=_unitOfWork._employeesRepos.Find(fm.EmployeeId);
            _fatDetailModel.Customers = cus;
            _fatDetailModel.Employess=emp;//FatDetailModel kısmına eklediğimiz için buraya yazabildik
            _fatDetailModel.FatMaster = fm; 
            _fatDetailModel.Products=_unitOfWork._productsRepos.GetProductsSelectList();
            _fatDetailModel.FatDetailList = _unitOfWork._fatDetailRepos.GetFatDetailList(id);
            return View(_fatDetailModel);
        }
        [HttpPost]
        public IActionResult Create(int id,FatDetailModel fatDetailModel)
        {
            Products products = _unitOfWork._productsRepos.Find(_fatDetailModel.ProductId);
            //_fatDetailModel.UnitPrice = products.UnitPrice;
           // _fatDetailModel.Total = products.UnitPrice * _fatDetailModel.Amount;
            _fatDetail.UnitPrice = products.UnitPrice;
            _fatDetail.Anount = _fatDetailModel.Amount;
            _fatDetail.ProductId=_fatDetailModel.ProductId;
            _fatDetail.Id = id; //Fatdetailcontroller dan gelen id
            _unitOfWork._fatDetailRepos.Create(_fatDetail);
            _unitOfWork.Save();
            fatDetailModel.FatMaster = _unitOfWork._fatMasterRepos.Find(id);
            fatDetailModel.Products = _unitOfWork._productsRepos.GetProductsSelectList();
            fatDetailModel.FatDetailList = _unitOfWork._fatDetailRepos.GetFatDetailList(id);
            return View(fatDetailModel);
        }

    }
}
