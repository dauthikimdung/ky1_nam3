using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMVC.Entities;
using BookMVC.Dao;
using BookMVC.Models;
using System.IO;
using System.Web.Routing;

namespace BookMVC.Controllers
{
     public class CartController : Controller
     {
          BookMVCDbContext db = new BookMVCDbContext();
          // Tạo giỏ
          public List<CartItemDetail> CreateCart(long? UserID)
          {
               var cart = (from b in db.Books
                           join i in db.CartItems
                           on b.ID equals i.ItemID
                           where i.CustomerID == UserID
                           select new CartItemDetail() {
                                ItemID = b.ID,
                                Name = b.Name,
                                Price = b.Price,
                                PromotionPrice = b.PromotionPrice,
                                Author = (int)b.Author,
                                Image = b.Image,
                                Inventory = b.Inventory,
                                MetaTitle = b.MetaTitle,
                                Quantity = i.Quantity,
                                Selected = true
                          }).ToList();
               Session["Cart"] = cart;
               return cart;
          }

          // Lấy danh sách item trong Cart 
          public List<CartItemDetail> TakeCart()
          {
               return Session["Cart"] as List<CartItemDetail>;
          }
          // Tong so san pham
          public decimal? TotalQuantity
          {
               get
               {
                    var cart = TakeCart();
                    if (cart == null || cart.Sum(x => x.Quantity) == 0)
                         return 0;
                    return cart.Sum(x => x.Quantity);
               }
          }

          // Tong tien
          public decimal? TotalPrice
          {
               get
               {
                    var cart = TakeCart();
                    if (cart == null || cart.Sum(x => x.Quantity) == 0)
                         return 0;
                    decimal? sum = 0;
                    foreach (var i in cart)
                    {
                         sum += (i.PromotionPrice * i.Quantity);
                    }
                    return sum;
               }
          }
          public decimal? TotalSelectedPrice
          {
               get
               {
                    var cart = TakeCart().Where(x => x.Selected == true).ToList();
                    if (cart == null || cart.Sum(x => x.Quantity) == 0)
                         return 0;
                    decimal? sum = 0;
                    foreach (var i in cart)
                    {
                         sum += (i.Price * i.Quantity);
                    }
                    return sum;
               }
          }

          public decimal? TotalPromotion
          {
               get
               {
                    var cart = TakeCart().Where(x => x.Selected == true).ToList();
                    if (cart == null || cart.Sum(x => x.Quantity) == 0)
                         return 0;
                    decimal? sum = 0;
                    foreach (var i in cart)
                    {
                         sum += ((i.Price-i.PromotionPrice) * i.Quantity);
                    }
                    return sum;
               }
          }
          // So luong sach trong gio hang hien thi tren TopNavBar va khoi tao Session["Cart"]
          public ActionResult CartPartial()
          {
               var UserID = Session["UserID"] as long?;
               if (Session["Cart"] == null && UserID != null)
                    CreateCart(UserID);
               ViewBag.TotalQuantity = TotalQuantity;
               ViewBag.TotalPrice = TotalPrice;
               return PartialView();
          }

          // Cập nhật số lượng giỏ khi thêm, sửa, xóa giỏ
          [HttpPost]
          public JsonResult Cart()
          {
               var UserID = Session["UserID"] as long?;
               if (Session["Cart"] == null && UserID != null )
                    CreateCart(UserID);
               return Json(new
               {
                    totalprice = TotalPrice,
                    totalquantity = TotalQuantity });
          }

          // Danh sach sach trong gio hang
          public ActionResult Index(long? listShippingType)
          {
               if (Session["UserID"] == null)
               {
                    TempData["message"] = "Please Login First";
                    return RedirectToAction("Index", "Home");
               }
               if (TotalQuantity== 0)
               {
                    TempData["message"] = "There's no item in cart! Let shopping now!!";
                    return RedirectToAction("Index", "Home");
               }
               if (listShippingType == null)
               {
                    listShippingType = 1;
               }
               var group = new IndexCartModel
               {
                    cart = TakeCart(),
                    totalPrice = TotalSelectedPrice,
                    totalQuantity = TotalQuantity,
                    totalPromotion = TotalPromotion,
                    listHotBook = new BookDao().ListHotBook(20,4)
               };
               return View(group);
          }

          // Chuyen 1 partial view sang dang text Html de truyen vào ajax
          public string RenderRazorViewToString(string viewName, object model)
          {
               ViewData.Model = model;
               using (var sw = new StringWriter())
               {
                    var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                    var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                    return sw.GetStringBuilder().ToString();
               }
          }

          // + Thêm Item vào Cart
          // - Thêm trong giao diện giỏ
          [HttpPost]
          public ActionResult AddCartItemInCart(long ItemID)
          {
               var inventory = new BookDao().getInventory(ItemID);
               if (inventory == 0)
                    return Json(new
                    {
                         stringView = "Số lượng hàng trong kho không đủ!",
                         status = false
                    });
               var UserID = Session["UserID"] as long?;
               new CartItemDao().AddItem((long)UserID, ItemID,null);
               Session["Cart"] = CreateCart(UserID);
               var group = new IndexCartModel
               {
                    cart = CreateCart(UserID),
                    totalPrice = TotalSelectedPrice,
                    totalQuantity = TotalQuantity,
                    totalPromotion = TotalPromotion,
                    listHotBook = new BookDao().ListHotBook(20,4)
               };
               return PartialView("ContentCart", group);
          }

          // - Thêm ở ngoài giao diện giỏ
          [HttpPost]
          public ActionResult AddCartItem(long ItemID, int? Quantity)
          {
               int check;
               var inventory = new BookDao().getInventory(ItemID);
               if (inventory == 0)
                    return Json(check = 0);
               var UserID = Session["UserID"] as long?;
               // Kiem tra dang nhap
               if (UserID == null)
               {
                    Session["message"] = "Please Login First";
                    return Json(check = 1);
               }
               new CartItemDao().AddItem((long)UserID, ItemID, Quantity);
               Session["Cart"] = CreateCart(UserID);
               return Json(check = 2);
          }

          // + Xoa Item trong Cart
          [HttpPost]
          public JsonResult DeleteCartItem(long? ItemID)
          {
               var UserID = (long)Session["UserID"];
               var dao = new CartItemDao();
               var item = dao.TakeItem(UserID, (long)ItemID);
               if (item != null)
               {
                    dao.DeleteItem(UserID,item.ItemID);
                    var newcart = CreateCart(UserID);
                    Session["Cart"] = newcart;
                    var group = new IndexCartModel
                    {
                         cart = newcart,
                         totalPrice = TotalSelectedPrice,
                         totalQuantity = TotalQuantity,
                         totalPromotion = TotalPromotion,
                         listHotBook = new BookDao().ListHotBook(20,4)
                    };
                    return Json(new
                    {
                         stringView = RenderRazorViewToString("ContentCart", group),
                         status = true
                    });
               }
               
               return Json(new
               {
                    error = "Khong co san pham nay trong gio hang",
                    status = true
               });
          }

          // Cập nhật giỏ hàng
          //[HttpPost]
          //[ValidateAntiForgeryToken]
          //public ActionResult UpdateCartAll(FormCollection form)
          //{
          //     var cartdao = new CartItemDao();
          //     var UserID = Session["UserID"] as long?;
          //     var cart = TakeCart();
          //     foreach (var i in cart)
          //     {
          //          var namebox = "Quantity+" + i.ItemID;
          //          var Quantity = int.Parse(form[namebox].ToString());
          //          if (cartdao.TakeItem(UserID, i.ItemID) != null)
          //          {
          //               cartdao.UpdateItem(UserID, i.ItemID, Quantity);
          //               i.Quantity = Quantity;
          //          }
          //          var namebox2 = "Selected+" + i.ItemID;
          //          if (form[namebox2] == null )
          //               i.Selected = false;
          //          else i.Selected = true;
          //     }
          //     Session["Cart"] = cart;
          //     var group = new IndexCartModel
          //     {
          //          cart = cart,
          //          totalPrice = TotalSelectedPrice,
          //          totalQuantity = TotalQuantity,
          //          totalPromotion = TotalPromotion,
          //          listHotBook = new BookDao().ListHotBook(20,4)
          //     };
          //     return Json(new
          //     {
          //          stringView = RenderRazorViewToString("ContentCart",group),
          //          status = true
          //     });
          //}
         
          [HttpPost]
          public JsonResult ShippingCost(string value,string total)
          {
               var v = long.Parse(value);
               var t = decimal.Parse(total);
               var ship = new ShipDao().TakeByID(v);
               return Json(new
               {
                    cost = ship.Cost.ToString("N0") + " VNĐ",
                    time = ship.Time
                    //total = (ship.Cost + t).ToString("N0")
               });
          }

          [HttpPost]
          public ActionResult UpdateQuantity(long ItemID,int quantity)
          {
               var cartdao = new CartItemDao();
               var UserID = Session["UserID"] as long?;
               var cart = TakeCart();
               var namebox = "Quantity+" + ItemID;
               var item = cartdao.TakeItem(UserID, ItemID);
               if ( item != null)
               {
                    cartdao.UpdateItem(UserID, ItemID, quantity);
                    cart.ToList().Where(x => x.ItemID == ItemID).Single().Quantity = quantity;
               }
               Session["Cart"] = cart;
               var group = new IndexCartModel
               {
                    cart = cart,
                    totalPrice = TotalSelectedPrice,
                    totalQuantity = TotalQuantity,
                    totalPromotion = TotalPromotion,
                    listHotBook = new BookDao().ListHotBook(20,4)
               };
               return Json(new
               {
                    stringView = RenderRazorViewToString("ContentCart", group),
                    totalPromotion =((decimal)TotalPromotion).ToString("N0") ,
                    totalPrice = ((decimal)TotalSelectedPrice).ToString("N0"),
                    realPrice = ((decimal)(TotalSelectedPrice - TotalPromotion)).ToString("N0"),
                    status = true
               });
          }
     }
}