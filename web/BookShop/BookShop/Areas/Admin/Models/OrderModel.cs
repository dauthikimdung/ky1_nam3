using BookShop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookShop.Areas.Admin.Models
{
    public class OrderModel
    {
        private BookShopDbContext context;
        public OrderModel()
        {
            context = new BookShopDbContext();
        }
        public IEnumerable<Order> ListAllPaging(int page = 1, int pageSize = 10)
        {
            var list = context.Database.SqlQuery<Order>("sp_Orders_ListAll").ToPagedList(page, pageSize);
            return list;
        }
        public Order GetOrderById(string id)
        {

            var list = context.Database.SqlQuery<Order>("sp_Orders_ListAll").ToList();
            foreach(var item in list)
            {
                if(item.MaDH.Contains(id))
                {
                    return item;
                }
            }
            //order.MaDH = entity.MaDH;
            //    order.TenDH = entity.TenDH;
            //    order.TinhTrangGH = entity.TinhTrangGH;
            //    order.TinhTrangTT = entity.TinhTrangTT;
            //    order.NgayDat = entity.NgayDat;
            //    order.NgayGiao = entity.NgayGiao;
            //    order.TongTien = entity.TongTien;
            //    order.MaKH = entity.MaKH;
            //    order.MaSP = detail.MaSP;
            //    order.SoLuong = detail.SoLuong;
            //    order.DonGia = detail.DonGia;



            return null;
        }
        public bool Delete(string orderID)
        {
                var order = context.DonHang.Find(orderID);
            //var details = context.Database.SqlQuery<ChiTietDonHang>("sp_OrderDetails_ListAll").ToList();
            //foreach(ChiTietDonHang item in details)
            //{
            //    if(item.MaDH.Contains(orderID))
            //    {
            //        context.ChiTietDonHang.Remove(item);
            //    }
            //}
            var deletedCustomer = context.ChiTietDonHang.Where(c => c.MaDH.Contains(orderID)).FirstOrDefault();
            context.ChiTietDonHang.Remove(deletedCustomer);
            context.DonHang.Remove(order);
                context.SaveChanges();
                return true;

        }
    }
}