using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using Model.Model;
using System.Data.Entity.Validation;

namespace Model.DAO
{
    public class BookDao
    {
        SachDbContext db = null;
        public BookDao()
        {
            db = new SachDbContext();
        }
       
        public IEnumerable<Book> ListAllPaging(string searchString,int page, int pageSize)
        {
            IQueryable<Book> model = db.Book;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString)) ;  //|| x.Author.Contains(searchString))

            }
            return model.OrderByDescending(x => x.PublishDate).ToPagedList(page, pageSize);

        }
        public IEnumerable<BookModel> ListAllByTag(string searchString, int page, int pageSize)
        {
            var news = (from a in db.Book
                        join b in db.BookCategory on a.CategoryID equals b.ID into cates
                        from y1 in cates.DefaultIfEmpty()
                        join c in db.Author on a.Author equals c.ID into authors
                        from y2 in authors.DefaultIfEmpty()
                        join d in db.Publisher on a.Publisher equals d.ID into pubs
                        from y3 in pubs.DefaultIfEmpty()
                        join f in db.Publisher on a.Released equals f.ID into rels
                        from y4 in rels.DefaultIfEmpty()
                        select new BookModel()
                        {
                            Book=a,
                            NameType = y1.Name,
                            NameAuthor = y2.Name,
                            NamePublisher = y3.Name,
                            NameReleased = y4.Name
                        }) ;
            if (!string.IsNullOrEmpty(searchString))
            {
                news = news.Where(x => x.Book.Name.Contains(searchString) || x.NameAuthor.Contains(searchString)||x.NamePublisher.Contains(searchString)||x.NameReleased.Contains(searchString)); 

            }
            return news.OrderByDescending(x => x.Book.PublishDate).ToPagedList(page, pageSize);
        }
        public bool Update(Book entity,string s)
        {
            try
            {
                var book = db.Book.Find(entity.ID);
                book.Code = entity.Code;
                book.Name = entity.Name;
                book.Author = entity.Author;
                book.Released = entity.Released;
                book.Publisher = entity.Publisher;
                book.Weight = entity.Weight;
                book.Form = entity.Form;
                book.NumberPage = entity.NumberPage;
                book.PublishDate = entity.PublishDate;
                book.MetaTitle = Str_Metatitle(entity.Name);
                book.Description = entity.Description;
                book.Image = entity.Image;
                book.Price = entity.Price;
                book.PromotionPrice = entity.PromotionPrice;
                book.CategoryID = entity.CategoryID;
                book.CreateBy = s;
                db.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public Book GetById(string bookName)
        {
            return db.Book.SingleOrDefault(x => x.Name == bookName);
        }
        public Book ViewDetail(long id)
        {
            return db.Book.Find(id);
        }
        
        public bool Delete(int id)
        {
            try
            {
                var bk = db.Book.Find(id);
                db.Book.Remove(bk);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
   
        public List<string> Form()
        {
            var listForm = new List<string>();
            listForm.Add("Bìa mềm");
            listForm.Add("Bìa cứng");

            return listForm;
        }
        public List<Book> ListAll()
        {
            return db.Book.Where(x => x.Status == true).OrderByDescending(x => x.PublishDate < DateTime.Now).ToList();
        }
        public bool ChangeStatus(int id)
        {
            var book = db.Book.Find(id);
            book.Status = !book.Status;
            db.SaveChanges();
            return (bool)book.Status;
        }
      
        public bool addBook(Book entity,string s)
        {
            try
            {
                var book = new Book();
                book.Code = entity.Code;
                book.Name = entity.Name;
                book.Author = entity.Author;
                book.Released = entity.Released;
                book.Publisher = entity.Publisher;
                book.Weight = entity.Weight;
                book.Form = entity.Form;
                book.NumberPage = entity.NumberPage;
                book.PublishDate = entity.PublishDate;
                book.MetaTitle = Str_Metatitle(entity.Name);
                book.Description = entity.Description;
                book.Image = entity.Image;
                book.Price = entity.Price;
                book.PromotionPrice = entity.PromotionPrice;
                book.CategoryID = entity.CategoryID;
                book.CreateDate = DateTime.Now;
                book.Status = true;
                book.CreateBy = s;
                db.Book.Add(book);
                db.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    var x = "Entity of type " + eve.Entry.Entity.GetType().Name + " in state " + eve.Entry.State + " has the following validation errors:";
                    string Property;
                    string Error;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Property = ve.PropertyName;
                        Error = ve.ErrorMessage;
                    }
                }
                throw;
                return false;
            }


        }
        //Chuyển tên sách thành metatitle
        public string Str_Metatitle(string str)
        {
            string[] VietNamChar = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ:"
            };
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            string str1 = str.ToLower();
            string[] name = str1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string meta = null;
            //Thêm dấu '-'
            foreach (var item in name)
            {
                meta = meta + item + "-";
            }
            return meta;
        }
        public List<string> Listsearch(string search)
        {
            var model = (from a in db.Book
                        join b in db.BookCategory on a.CategoryID equals b.ID
                        join c in db.Author on a.Author equals c.ID
                        join d in db.Publisher on a.Publisher equals d.ID
                        join f in db.Publisher on a.Released equals f.ID
                        select new BookModel()
                        {
                            Book = a,
                            NameAuthor = c.Name,

                            NamePublisher = d.Name,
                            NameReleased = f.Name,
                            NameType = b.Name
                        });
            var ls = (from x in model
                     where x.Book.Name.Contains(search)
                     select x.Book.Name).ToList();
            var lsAuthor = (from x in model
                           where x.NameAuthor.Contains(search)
                           select x.NameAuthor).AsEnumerable();
            var lsPulisher = (from x in model
                            where x.NamePublisher.Contains(search)
                            select x.NamePublisher).AsEnumerable();
            var lsRealed = (from x in model
                              where x.NameReleased.Contains(search)
                              select x.NameReleased).AsEnumerable();
            ls.AddRange(lsAuthor);
            ls.AddRange(lsPulisher);
            ls.AddRange(lsRealed);
            return ls;
        }
        public bool Import(string Code, int quantity)
        {
            var book = db.Book.Where(x => x.Code == Code).SingleOrDefault();
            if (book == null)
                return false;
            book.Inventory += quantity;
            db.SaveChanges();
            return true;
        }
    }
}

