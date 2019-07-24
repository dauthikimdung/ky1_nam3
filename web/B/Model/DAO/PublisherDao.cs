﻿using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class PublisherDao
    {
        SachDbContext db = null;
        public PublisherDao()
        {
            db = new SachDbContext();

        }
        public List<EF.Publisher> ListAll()
        {
            return db.Publisher.ToList();
        }
        
        public IEnumerable<Publisher> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Publisher> model = db.Publisher;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));

            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);

        }

        public bool Update(Publisher entity)
        {
            try
            {
                var model = db.Publisher.Find(entity.ID);
                model.Name = entity.Name;
                model.Address = entity.Address;
                model.Description = entity.Description;
            
                model.Image = entity.Image;
                db.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }


        }


        public Publisher ViewDetail(long id)
        {
            return db.Publisher.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var bk = db.Publisher.Find(id);
                db.Publisher.Remove(bk);
                var book = db.Book.Where(x => x.Publisher == id).ToList();
                if (book != null)
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
            
                var bk = db.Publisher.Find(id);
                var book = db.Book.Where(x => x.Publisher == id).ToList();
                if (book != null)
                {
                    foreach (var a in book)
                    {
                        a.Publisher= 0;
                    }
                }

                db.Publisher.Remove(bk);
                db.SaveChanges();
                return true;

            


        }


        public bool addPublisher(Publisher entity)
        {
            try
            {
                Publisher model = new Publisher();
                model.Name = entity.Name;
                model.MetaTitle = Str_Metatitle(entity.Name);
                model.Address = entity.Address;
                model.Description = entity.Description;
                model.Status = true;
                model.Image = entity.Image;
                model.CreatedDate = DateTime.Now;
                db.Publisher.Add(model);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }
       public List<string> ListName(string c)
        {
            return db.Publisher.Where(x => x.Name.Contains(c)).Select(x => x.Name).ToList();
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
        public List<string> Listsearch(string search)
        {
            return db.Publisher.Where(x => x.Name.Contains(search)).Select(x => x.Name).ToList();
        }
        public bool ChangeStatus(int id)
        {
            var model = db.Publisher.Find(id);
            model.Status = !model.Status;
            db.SaveChanges();
            return (bool)model.Status;
        }
    }
}
