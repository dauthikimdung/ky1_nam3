using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.EF;

namespace Model.DAO
{
    public class NewTypeDao
    {
        SachDbContext db = null;
        public NewTypeDao()
        {
            db = new SachDbContext();
        }
        public List<NewsType> ListAll()
        {
            return db.NewsType.Where(x => x.Status == true).ToList();
        }
        
    }
}
