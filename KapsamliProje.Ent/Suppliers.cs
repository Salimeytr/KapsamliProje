using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapsamliProje.Ent
{
    public class Suppliers : Enterprize
    {
        public Suppliers()
        {
            Products = new HashSet<Products>();
        }
        public ICollection<Products> Products { get; set; }
        [ForeignKey("CityId")]
        public Cities Cities { get; set; }
        public int CityId { get; set; }
    }
}
