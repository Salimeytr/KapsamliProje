using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapsamliProje.Ent
{
    public class FatDetail
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Anount { get; set; }
        public decimal UnitPrice { get; set; }
        [ForeignKey("Id")] //Buradaki Id fatura masterdaki ID ile eşleşecek. 
        public FatMaster ?FatMaster { get; set; }
        
        public Products ?Products { get; set; }
    }
}

