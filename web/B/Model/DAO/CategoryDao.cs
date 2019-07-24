using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
     public class CategoryDao
    {
        SachDbContext db = null;
        public CategoryDao()
        {
            db =new  SachDbContext();
        }
        public List<Category> ListAll()
        {
            return db.Category.Where(x => x.Status == true).ToList();
        }
        public IEnumerable<Category> ListAllpage(string searching,int page,int pagesize)
        {
            IQueryable<Category> model = db.Category;
            if(!string.IsNullOrEmpty(searching))
            {
                model = model.Where(x => x.Name.Contains(searching));
            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page,pagesize);
        }
        public bool  ChangeStatus(int id)
        {
            var category = db.Category.Find(id);
            category.Status = !category.Status;
            db.SaveChanges();
            return category.Status;


        }
        public bool Update(Category entity)
        {
            try
            {
                var model = db.Category.Find(entity.ID);
                model.Name = entity.Name;
                model.MetaTitle = Str_Metatitle(entity.Name);
                model.DisplayOrder = entity.DisplayOrder;
                db.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public bool add(Category entity,string a)
        {
            try
            {
                var model = new Category();
                model.Name = entity.Name;
                model.MetaTitle = Str_Metatitle(entity.Name);
                model.DisplayOrder = entity.DisplayOrder;
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = a;
                model.Status = true;

                db.Category.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }
        public List<string> Listsearch(string search)
        {
            return db.Category.Where(x => x.Name.Contains(search)).Select(x => x.Name).ToList();
        }
        public Category ViewDetail(long id)
        {
            return db.Category.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var bk = db.Category.Find(id);
                db.Category.Remove(bk);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
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
    }
}
