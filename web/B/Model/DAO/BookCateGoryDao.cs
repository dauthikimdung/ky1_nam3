using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.DAO
{
   public class BookCateGoryDao
    {
        SachDbContext db = null;
        public BookCateGoryDao()
        {
            db = new SachDbContext();
        }

        public List<BookCategory> ListAll()
        {
            return db.BookCategory.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public BookCategory ViewDetail(long id)
        {
            return db.BookCategory.Find(id);
        }

        public List<BookCategory> ListBookCategory(long id)
        {
            return db.BookCategory.Where(x => x.ParentID == id).ToList();
        }
    }
}
