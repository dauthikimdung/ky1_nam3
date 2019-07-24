using BookShop.Areas.Admin.Models;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult Index(int page = 1, int pageSize = 20)
        {
            var orderModel = new OrderModel();
            var model = orderModel.ListAllPaging(page, pageSize);
            ViewBag.page = page;
            return View(model);
        }
        public ActionResult Details(string id)
        {
            var order = new OrderModel().GetOrderById(id);
            order.MaKH = new UserModel().GetUserById(order.MaKH).HoTenKH;
            order.MaSP = new ProductModel().GetProductById(order.MaSP).TenSP;
            return View(order);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = new OrderModel().GetOrderById(id);

            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);

        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var orderModel = new OrderModel();
              Order order=  orderModel.GetOrderById(id);

                bool c = orderModel.Delete(id);
                if (c)
                {
                    return RedirectToAction("FormDelete", "Order");
                }

            return RedirectToAction("FormDelete", "Order");
        }
    }
}