using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMVC.Entities;
using BookMVC.Models;
namespace BookMVC.Dao
{
     public class CartItemDao
     {
          BookMVCDbContext db;
          public CartItemDao()
          {
               db = new BookMVCDbContext();
          }
          // Lay Item
          public CartItem TakeItem(long? UserID, long ItemID) => db.CartItems.SingleOrDefault(x => x.CustomerID == UserID && x.ItemID == ItemID);
          // Lấy Danh sách Item trong Cart
          public List<CartItem> ListItem(long? UserID)
          {
               if (UserID == null)
                    return null;
               return (db.CartItems.Where(x => x.CustomerID == UserID).ToList());
          }
          // Thêm mới Item vào Cart
          public int AddItem(long UserID,long ItemID, int? Quantity)
          {
               var user = db.Users.SingleOrDefault(x => x.ID == UserID);
               var book = db.Books.SingleOrDefault(x => x.ID == ItemID);
               // Nếu hợp lệ
               if (book != null && user != null)
               {
                    var existed = TakeItem(UserID,ItemID);
                    // Nếu Item không có trong Cart
                    if (existed == null)
                    {
                         var item = new CartItem()
                         {
                              CustomerID = UserID,
                              ItemID = ItemID,
                              DateAdded = DateTime.Now
                         };
                         if (Quantity == null)
                              item.Quantity = 1;
                         else
                              item.Quantity = Quantity;

                         db.CartItems.Add(item);
                         db.SaveChanges();                         
                    }
                    // Nếu đã có trong Cart
                    else 
                    {
                         if (Quantity == null)
                              existed.Quantity++;
                         else
                              existed.Quantity += Quantity;
                         existed.DateAdded = DateTime.Now;
                         db.SaveChanges();
                    }
                    return 1;
               }
               return 0; // Lhong co sach, khong co tai khoan
          }
          // Cập nhật số lượng
          public void UpdateItem(long? UserID,long? ItemID,int Quantity)
          {
               var item = db.CartItems.SingleOrDefault(x => x.ItemID == ItemID && x.CustomerID == UserID);
               if (Quantity == 0)
               {
                    db.CartItems.Remove(item);
               }
               item.Quantity = Quantity;
               db.SaveChanges();
          }
          // Xóa Item khỏi Cart
          public void DeleteItem(long UserID,long? ItemID)
          {
               var item = db.CartItems.Where(x => x.ItemID == ItemID && x.CustomerID == UserID).SingleOrDefault();
               if (item != null)
               {
                    db.CartItems.Remove(item);
                    db.SaveChanges();
               }
          }
          // Xóa toàn bộ Cart 
          public void DeleteAllItem(long UserID)
          {
               var cart = ListItem(UserID);
               foreach(var i in cart)
               {
                    db.CartItems.Remove(i);
               }
               db.SaveChanges();
          }     
          public bool CheckUpToDate(List<CartItem> CartInDB)
          {
               return db.CartItems.ToList() != CartInDB;
          }
     }
}