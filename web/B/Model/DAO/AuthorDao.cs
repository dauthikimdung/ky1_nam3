using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
   public class AuthorDao
    {
        SachDbContext db = null;
        public AuthorDao()
        {
            db = new SachDbContext();

        }
        public List<Author>ListAll()
        {
            return db.Author.ToList();
        }
        public IEnumerable<Author> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Author> model = db.Author;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));  

            }
            return model.OrderByDescending(x => x.DateOfBirth).ToPagedList(page, pageSize);

        }
      
        public bool Update(Author entity)
        {
            try
            {
                var model = db.Author.Find(entity.ID);
                model.Name = entity.Name;
                model.DateOfBirth = entity.DateOfBirth;
                model.Description = entity.Description;
                model.Type = entity.Type;
                model.Image = entity.Image;
                db.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }


        }

       
        public Author ViewDetail(long id)
        {
            return db.Author.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var bk = db.Author.Find(id);
                db.Author.Remove(bk);
                var book = db.Book.Where(x => x.Author == id).ToList();
                if(book!=null)
                {
                    foreach (var a in book)
                    {
                        db.Book.Remove(a);
                    }
                }

                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool SetNull(int id)
        {
            try
            {
                var bk = db.Author.Find(id);                
                var book = db.Book.Where(x => x.Author == id).ToList();
                if(book!=null)
                {
                    foreach (var a in book)
                    {
                        a.Author = null;
                    }
                }

                db.Author.Remove(bk);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }

        public bool addAuthor(Author entity)
        {
            try
            {
                Author model = new Author();
                model.Name = entity.Name;
                model.DateOfBirth = entity.DateOfBirth;
                model.Description = entity.Description;
                model.Type = entity.Type;
                model.Image = entity.Image;
              
                db.Author.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }
        public List<string> Form()
        {
            var listForm = new List<string>();
            listForm.Add("Trong nước");
            listForm.Add("Nước ngoài");

            return listForm;
        }

        public List<string> ListName(string c)
        {
            return db.Author.Where(x => x.Name.Contains(c)).Select(x => x.Name).ToList();
        }

    }
}
