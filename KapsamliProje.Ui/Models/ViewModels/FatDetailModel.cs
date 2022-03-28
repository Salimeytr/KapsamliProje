using KapsamliProje.Dto;
using KapsamliProje.Ent;

namespace KapsamliProje.Ui.Models.ViewModels
{
    public class FatDetailModel
    {
        public Customer ?Customers  { get; set; } //Customer olursa customer name vs gelicek
        public FatMaster ?FatMaster { get; set; } //Buradan da tarihi alabiliriz
        public Employees ?Employess { get; set; } //Buraya eklediğimizde fatdetailcontrolelr kısmında kullanabiliyoruz
        public int ProductId { get; set; }
        public List<ProductsSelect> ?Products { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }
        public List<FatDetailList> ?FatDetailList { get; set; }
    }
}
