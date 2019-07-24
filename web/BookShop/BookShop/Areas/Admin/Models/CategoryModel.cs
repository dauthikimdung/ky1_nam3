using BookShop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Areas.Admin.Models
{
    public class CategoryModel
    {
        private BookShopDbContext context;
        public CategoryModel()
        {
            context = new BookShopDbContext();
        }
        public List<LinhVuc> ListAll()
        {
            var list = context.Database.SqlQuery<LinhVuc>("sp_Categories_ListAll").ToList();
            return list;
        }
        public IEnumerable<LinhVuc> ListAllPaging(int page = 1, int pageSize = 10)
        {
            var list = context.Database.SqlQuery<LinhVuc>("sp_Categories_ListAll").ToPagedList(page, pageSize);
            return list;
        }
        public IEnumerable<LinhVuc> ListAllSearch(string searchString,int page = 1, int pageSize = 10)
        {
            IEnumerable<BookShop.Models.LinhVuc> list = context.Database.SqlQuery<LinhVuc>("sp_Categories_ListAll");
            if(!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.MaLinhVuc.Contains(searchString) || x.TenLinhVuc.Contains(searchString) || x.NgaySua.ToString().Contains(searchString));

            }
            return list.ToPagedList(page,pageSize);
        }

        internal IEnumerable<LinhVuc> ListAllSearchID(string searchString, int page, int pageSize)
        {
            IEnumerable<BookShop.Models.LinhVuc> list = context.Database.SqlQuery<LinhVuc>("sp_Categories_ListAll");
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.MaLinhVuc.Contains(searchString));

            }
            return list.ToPagedList(page, pageSize);
        }

        internal IEnumerable<LinhVuc> ListAllSearchName(string searchString, int page, int pageSize)
        {
            IEnumerable<BookShop.Models.LinhVuc> list = context.Database.SqlQuery<LinhVuc>("sp_Categories_ListAll");
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.TenLinhVuc.Contains(searchString) );

            }
            return list.ToPagedList(page, pageSize);
        }

        public bool Insert(LinhVuc entity)
        {
            context.LinhVuc.Add(entity);
            context.SaveChanges();
            return true;
        }
        public bool Check(LinhVuc entity)
        {
            var x = context.LinhVuc.Find(entity.MaLinhVuc);
            if (x == null)
                return false;
            else
                return true;
        }
        public LinhVuc GetCategoryById(string id)
        {
            try
            {
                var cate = context.LinhVuc.Find(id);
                return cate;
            }catch(Exception e)
            {
                return null;
            }
        }
        public LinhVuc GetCategoryByName(string name)
        {
            try
            {
                var list = context.Database.SqlQuery<LinhVuc>("sp_Categories_ListAll").ToList();
                foreach(var item in list)
                {
                    if(item.TenLinhVuc.Contains(name))
                    {
                        return item;
                    }
                }
                
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }
        public bool Update(LinhVuc entity)
        {
            try
            {
                var category = context.LinhVuc.Find(entity.MaLinhVuc);
                category.TenLinhVuc = entity.TenLinhVuc;
                category.NgaySua = entity.NgaySua;
                context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        public bool Delete(string categoryID)
        {
            try
            {
                var category = context.LinhVuc.Find(categoryID);
                context.LinhVuc.Remove(category);
                context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }
    }
}