using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Data.SqlClient;

namespace BookShop.Areas.Admin.Models
{
    public class UserModel
    {
        private BookShopDbContext context;
        public UserModel()
        {
            context = new BookShopDbContext();
        }

        public NguoiDung GetByUserName(string userName)
        {
            return context.NguoiDung.SingleOrDefault(x => x.TenDangNhap == userName);
        }
        public bool Login(string user, string pass)
        {
            var result = context.NguoiDung.Count(x => x.TenDangNhap == user && x.MatKhau == pass && x.LoaiTK == 1);
            if (result > 0)
            {
                return true;
            }
            else return false;
        }
        public IEnumerable<NguoiDung> ListAllPaging(int page=1, int pageSize=10)
        {
            var list = context.Database.SqlQuery<NguoiDung>("sp_Users_ListAll").ToPagedList(page, pageSize);
            return list;
        }

        public NguoiDung GetUserByUserName(string username)
        {
            // Viet lai ham nay
                List<NguoiDung> list = context.Database.SqlQuery<NguoiDung>("sp_Users_ListAll").ToList();
                if (!string.IsNullOrEmpty(username))
                {
                    foreach(var item in list)
                    {
                        if(item.TenDangNhap.TrimEnd().Equals(username))
                        {
                            return item;
                        }
                    }
                }

            return null;
        }
        public NguoiDung GetUserById(string id)
        {
            try
            {
                var user = context.NguoiDung.Find(id);
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool Update(NguoiDung entity)
        {
            try
            {
                var user = context.NguoiDung.Find(entity.MaKH);
                user.HoTenKH = entity.HoTenKH;
                user.DiaChi = entity.DiaChi;
                user.NgaySinh = entity.NgaySinh;
                user.GioiTinh = entity.GioiTinh;
                user.SoDienThoai = entity.SoDienThoai;
                user.Email = entity.Email;
                user.TenDangNhap = entity.TenDangNhap;
                user.MatKhau = entity.MatKhau;
                user.LoaiTK = entity.LoaiTK;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public IEnumerable<NguoiDung> ListAllSearch(string searchString, int page = 1, int pageSize = 10)
        {
            IEnumerable<BookShop.Models.NguoiDung> list = context.Database.SqlQuery<NguoiDung>("sp_Users_ListAll");
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.MaKH.Contains(searchString) || x.HoTenKH.Contains(searchString) || x.DiaChi.ToString().Contains(searchString)|| x.GioiTinh.ToString().Contains(searchString));

            }
            return list.ToPagedList(page, pageSize);
        }

        internal IEnumerable<NguoiDung> ListAllSearchID(string searchString, int page, int pageSize)
        {
            IEnumerable<BookShop.Models.NguoiDung> list = context.Database.SqlQuery<NguoiDung>("sp_Users_ListAll");
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.MaKH.Contains(searchString));

            }
            return list.ToPagedList(page, pageSize);
        }
        internal IEnumerable<NguoiDung> ListAllSearchName(string searchString, int page, int pageSize)
        {
            IEnumerable<BookShop.Models.NguoiDung> list = context.Database.SqlQuery<NguoiDung>("sp_Users_ListAll");
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.HoTenKH.Contains(searchString));

            }
            return list.ToPagedList(page, pageSize);
        }
        internal IEnumerable<NguoiDung> ListAllSearchAddress(string searchString, int page, int pageSize)
        {
            IEnumerable<BookShop.Models.NguoiDung> list = context.Database.SqlQuery<NguoiDung>("sp_Users_ListAll");
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.DiaChi.Contains(searchString));

            }
            return list.ToPagedList(page, pageSize);
        }
        public bool Delete(string userID)
        {
            try
            {
                var user = context.NguoiDung.Find(userID);
                context.NguoiDung.Remove(user);
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