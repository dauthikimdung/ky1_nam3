using BookShop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Areas.Admin.Models
{
    public class PublisherModel
    {
        private BookShopDbContext context;
        public PublisherModel()
        {
            context = new BookShopDbContext();
        }
        public NhaXuatBan GetPublisherByName(string name)
        {
            try
            {
                var list = context.Database.SqlQuery<NhaXuatBan>("sp_Publishers_ListAll").ToList();
                foreach (var item in list)
                {
                    if (item.TenNXB.Contains(name))
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
        public List<NhaXuatBan> ListAll()
        {
            var list = context.Database.SqlQuery<NhaXuatBan>("sp_Publishers_ListAll").ToList();
            return list;
        }
        public IEnumerable<NhaXuatBan> ListAllPaging(int page = 1, int pageSize = 10)
        {
            var list = context.Database.SqlQuery<NhaXuatBan>("sp_Publishers_ListAll").ToPagedList(page, pageSize);
            return list;
        }
        public IEnumerable<NhaXuatBan> ListAllSearch(string searchString, int page = 1, int pageSize = 10)
        {
            IEnumerable<BookShop.Models.NhaXuatBan> list = context.Database.SqlQuery<NhaXuatBan>("sp_Publishers_ListAll");
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.MaNXB.Contains(searchString) || x.TenNXB.Contains(searchString) || x.DiaChi.ToString().Contains(searchString));

            }
            return list.ToPagedList(page, pageSize);
        }

        internal IEnumerable<NhaXuatBan> ListAllSearchID(string searchString, int page, int pageSize)
        {
            IEnumerable<BookShop.Models.NhaXuatBan> list = context.Database.SqlQuery<NhaXuatBan>("sp_Publishers_ListAll");
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.MaNXB.Contains(searchString));

            }
            return list.ToPagedList(page, pageSize);
        }

        internal IEnumerable<NhaXuatBan> ListAllSearchName(string searchString, int page, int pageSize)
        {
            IEnumerable<BookShop.Models.NhaXuatBan> list = context.Database.SqlQuery<NhaXuatBan>("sp_Publishers_ListAll");
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.TenNXB.Contains(searchString));

            }
            return list.ToPagedList(page, pageSize);
        }
        internal IEnumerable<NhaXuatBan> ListAllSearchAddress(string searchString, int page, int pageSize)
        {
            IEnumerable<BookShop.Models.NhaXuatBan> list = context.Database.SqlQuery<NhaXuatBan>("sp_Publishers_ListAll");
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.DiaChi.Contains(searchString));

            }
            return list.ToPagedList(page, pageSize);
        }
        public bool Insert(NhaXuatBan entity)
        {
            context.NhaXuatBan.Add(entity);
            context.SaveChanges();
            return true;
        }
        public bool Check(NhaXuatBan entity)
        {
            var x = context.NhaXuatBan.Find(entity.MaNXB);
            if (x == null)
                return false;
            else
                return true;
        }
        public NhaXuatBan GetPublisherById(string id)
        {
            try
            {
                var nxb = context.NhaXuatBan.Find(id);
                return nxb;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Update(NhaXuatBan entity)
        {
            try
            {
                var nxb = context.NhaXuatBan.Find(entity.MaNXB);
                nxb.TenNXB = entity.TenNXB;
                nxb.DiaChi = entity.DiaChi;
                nxb.SoDienThoai = entity.SoDienThoai;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool Delete(string nxbID)
        {
            try
            {
                var category = context.NhaXuatBan.Find(nxbID);
                context.NhaXuatBan.Remove(category);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}