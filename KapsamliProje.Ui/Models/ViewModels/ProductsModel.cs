using KapsamliProje.Dto;

namespace KapsamliProje.Ui.Models.ViewModels
{
    public class ProductsModel
    {
        public ProductsModel Products{ get; set; }
        public List<CategoriesList> categoriesLists { get; set; }
        public List<CitiesList> citiesList { get; set; }
        public List<CountiesList> countiesList { get; set; }

        public List<CustomersList> customersList { get; set; }
        public List<EmployeesList> employeesList { get; set; }
        public List<EndConsumersList> endconsumersList { get; set; }
        public List<SuppliersList> suppliersList { get; set; }
    }
}
