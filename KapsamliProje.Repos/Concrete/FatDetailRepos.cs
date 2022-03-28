using KapsamliProje.Core;
using KapsamliProje.Dal;
using KapsamliProje.Dto;
using KapsamliProje.Ent;
using KapsamliProje.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapsamliProje.Repos.Concrete
{
    public class FatDetailRepos:BaseRepository<FatDetail>,IFatDetailRepos
    {
        public FatDetailRepos(Context db):base(db)
        {

        }

        public List<FatDetailList> GetFatDetailList(int id)
        {
            var ls = Query();
            return ls.Select(x => new FatDetailList
            {
                Amount = x.Anount,
                Id = x.Id,
                ProductName = x.Products.ProductName,
                Total = x.UnitPrice * x.Anount,
                UnitPrice = x.UnitPrice,
            }).Where(x => x.Id ==id).ToList();

        }

        public List<FatDetailList> GetFatDetailLists()
        {
            throw new NotImplementedException();
        }
    }
}
