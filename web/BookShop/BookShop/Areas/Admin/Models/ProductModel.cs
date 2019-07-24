using BookShop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Areas.Admin.Models
{
    public class ProductModel
    {
        BookShopDbContext context;
        public ProductModel()
        {
            context = new BookShopDbContext();
        }
        public IEnumerable<Product> ListAllPaging(int page = 1, int pageSize = 10)
        {
            var list = context.Database.SqlQuery<Product>("sp_Products_ListAll").ToPagedList(page, pageSize);
            foreach(var item in list)
            {
                item.MaLinhVuc = new CategoryModel().GetCategoryById(item.MaLinhVuc).TenLinhVuc;
                item.MaNXB = new PublisherModel().GetPublisherById(item.MaNXB).TenNXB;

            }
            return list;
        }
        public IEnumerable<Product> ListAllSearch(string searchString, int page = 1, int pageSize = 10)
        {
            List<Product> list = context.Database.SqlQuery<Product>("sp_Products_ListAll").ToList();
            foreach (var item in list)
            {
                item.MaLinhVuc = new CategoryModel().GetCategoryById(item.MaLinhVuc).TenLinhVuc;

                item.MaNXB = new PublisherModel().GetPublisherById(item.MaNXB).TenNXB;

            }
            List<Product> ls=new List<Product>();
            if (!string.IsNullOrEmpty(searchString))
            {
                foreach(var item in list)
                {
                    if ( item.MaSP.Contains(searchString) || item.TenSP.Contains(searchString) ||
                 item.TacGia.Contains(searchString) || item.MaNXB.Contains(searchString) ||
                 item.MaLinhVuc.Contains(searchString) || item.NgayXuatBan.ToString().Contains(searchString))
                    {
                        ls.Add(item);
                    }
                }

            }
            else
            {
                ls = list;
            }
            
            return ls.ToPagedList(page, pageSize);
        }
        public IEnumerable<Product> ListAllSearchID(string searchString, int page = 1, int pageSize = 10)
        {
            List<Product> list = context.Database.SqlQuery<Product>("sp_Products_ListAll").ToList();
            foreach (var item in list)
            {
                item.MaLinhVuc = new CategoryModel().GetCategoryById(item.MaLinhVuc).TenLinhVuc;
                item.MaNXB = new PublisherModel().GetPublisherById(item.MaNXB).TenNXB;

            }
            List<Product> ls = new List<Product>();

                foreach (var item in list)
                {
                    if (item.MaSP.Contains(searchString))
                    {
                        ls.Add(item);
                    }
                }

            return ls.ToPagedList(page, pageSize);
        }
        public IEnumerable<Product> ListAllSearchName(string searchString, int page = 1, int pageSize = 10)
        {
            List<Product> list = context.Database.SqlQuery<Product>("sp_Products_ListAll").ToList();
            foreach (var item in list)
            {
                item.MaLinhVuc = new CategoryModel().GetCategoryById(item.MaLinhVuc).TenLinhVuc;
                item.MaNXB = new PublisherModel().GetPublisherById(item.MaNXB).TenNXB;

            }
            List<Product> ls = new List<Product>();

            foreach (var item in list)
            {
                if (item.TenSP.Contains(searchString))
                {
                    ls.Add(item);
                }
            }

            return ls.ToPagedList(page, pageSize);
        }
        public IEnumerable<Product> ListAllSearchPublisher(string searchString, int page = 1, int pageSize = 10)
        {
            List<Product> list = context.Database.SqlQuery<Product>("sp_Products_ListAll").ToList();
            foreach (var item in list)
            {
                item.MaLinhVuc = new CategoryModel().GetCategoryById(item.MaLinhVuc).TenLinhVuc;
                item.MaNXB = new PublisherModel().GetPublisherById(item.MaNXB).TenNXB;

            }
            List<Product> ls = new List<Product>();

            foreach (var item in list)
            {
                if (item.MaNXB.Contains(searchString))
                {
                    ls.Add(item);
                }
            }

            return ls.ToPagedList(page, pageSize);
        }

        public IEnumerable<Product> ListAllSearchCatagory(string searchString, int page = 1, int pageSize = 10)
        {
            List<Product> list = context.Database.SqlQuery<Product>("sp_Products_ListAll").ToList();
            foreach (var item in list)
            {
                item.MaLinhVuc = new CategoryModel().GetCategoryById(item.MaLinhVuc).TenLinhVuc;
                item.MaNXB = new PublisherModel().GetPublisherById(item.MaNXB).TenNXB;

            }
            List<Product> ls = new List<Product>();

            foreach (var item in list)
            {
                if (item.MaLinhVuc.Contains(searchString))
                {
                    ls.Add(item);
                }
            }

            return ls.ToPagedList(page, pageSize);
        }
        public IEnumerable<Product> GetProductsByCategory(string categoryID)
        {
            IEnumerable<Product> list = context.Database.SqlQuery<Product>("sp_Products_ListAll");
            list=list.Where(x=>x.MaLinhVuc.Contains(categoryID)).ToList();
            return list;
        }

        public IEnumerable<Product> GetProductsByPublisher(string publisherID)
        {
            IEnumerable<Product> list = context.Database.SqlQuery<Product>("sp_Products_ListAll");
            list = list.Where(x => x.MaNXB.Contains(publisherID)).ToList();
            return list;
        }
        public bool Insert(Product entity)
        {
            SanPham product = new SanPham();
            product.MaSP = entity.MaSP;
            product.TenSP = entity.TenSP;
            product.GiaGoc = entity.GiaGoc;
            product.GiamGia = entity.GiamGia;
            product.SoLuong = entity.SoLuong;
            product.AnhBiaSP = entity.AnhBiaSP;
            product.TacGia = entity.TacGia;
            product.MaTTCT = entity.MaTTCT;
            product.MaLinhVuc = /*new CategoryModel().GetCategoryByName(*/ entity.MaLinhVuc/*).MaLinhVuc*/;
            product.MaNXB = /*new PublisherModel().GetPublisherByName(*/entity.MaNXB/*).MaNXB*/;
            product.Moi = entity.Moi;

            ThongTinChiTiet detail = new ThongTinChiTiet();
            detail.MaTTCT = entity.MaTTCT;
            detail.NgayXuatBan = entity.NgayXuatBan;
            detail.TrongLuong = entity.TrongLuong;
            detail.KichThuoc = entity.KichThuoc;
            detail.LoaiBia = entity.LoaiBia;
            detail.SoTrang = entity.SoTrang;
            detail.MoTaChiTiet = entity.MoTaChiTiet;

            context.SanPham.Add(product);
            context.ThongTinChiTiet.Add(detail);
            context.SaveChanges();
            return true;
        }
        public bool Check(Product entity)
        {
            var x = context.SanPham.Find(entity.MaSP);
            if (x == null)
                return false;
            else
                return true;
        }
        public Product GetProductById(string id)
        {
            try
            {
                var product = new Product();
                var entity = context.SanPham.Find(id);
                var detail = context.ThongTinChiTiet.Find(entity.MaTTCT);

                product.MaSP = entity.MaSP;
                product.TenSP = entity.TenSP;
                product.GiaGoc = entity.GiaGoc;
                product.GiamGia = entity.GiamGia;
                product.SoLuong = entity.SoLuong;
                product.AnhBiaSP = entity.AnhBiaSP;
                product.TacGia = entity.TacGia;
                product.MaTTCT = entity.MaTTCT;
                product.MaLinhVuc = /*new CategoryModel().GetCategoryByName(*/entity.MaLinhVuc/*).MaLinhVuc*/;
                product.MaNXB = /*new PublisherModel().GetPublisherByName(*/entity.MaNXB/*).MaNXB*/;
                product.Moi = entity.Moi;

                product.NgayXuatBan= detail.NgayXuatBan;
                product.TrongLuong= detail.TrongLuong;
                product.KichThuoc= detail.KichThuoc;
                product.LoaiBia= detail.LoaiBia;
                product.SoTrang= detail.SoTrang;
                product.MoTaChiTiet= detail.MoTaChiTiet;
                return product;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool Update(Product entity)
        {
            try
            {
                SanPham product = context.SanPham.Find(entity.MaSP);
                product.MaSP = entity.MaSP;
                product.TenSP = entity.TenSP;
                product.GiaGoc = entity.GiaGoc;
                product.GiamGia = entity.GiamGia;
                product.SoLuong = entity.SoLuong;
                product.AnhBiaSP = entity.AnhBiaSP;
                product.TacGia = entity.TacGia;
                product.MaTTCT = entity.MaTTCT;
                product.MaLinhVuc = /*new CategoryModel().GetCategoryByName(*/entity.MaLinhVuc/*).MaLinhVuc*/;
                product.MaNXB = /*new PublisherModel().GetPublisherByName(*/entity.MaNXB/*).MaNXB*/;
                product.Moi = entity.Moi;

                ThongTinChiTiet detail = context.ThongTinChiTiet.Find(entity.MaTTCT);
                detail.MaTTCT = entity.MaTTCT;
                detail.NgayXuatBan = entity.NgayXuatBan;
                detail.TrongLuong = entity.TrongLuong;
                detail.KichThuoc = entity.KichThuoc;
                detail.LoaiBia = entity.LoaiBia;
                detail.SoTrang = entity.SoTrang;
                detail.MoTaChiTiet = entity.MoTaChiTiet;

                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool Delete(string ID)
        {
            try
            {
                var product = context.SanPham.Find(ID);
                var detail = context.ThongTinChiTiet.Find(product.MaTTCT);
                context.SanPham.Remove(product);
                context.ThongTinChiTiet.Remove(detail);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool DeleteList(IEnumerable<Product> ls)
        {
            try
            {
                foreach(Product item in ls)
                {
                    Delete(item.MaSP);
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }
    }
}