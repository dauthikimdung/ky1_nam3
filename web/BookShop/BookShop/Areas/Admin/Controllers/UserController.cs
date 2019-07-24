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
    public class UserController : Controller
    {
        // GET: Admin/NguoiDung
        public ActionResult Index(int page=1, int pageSize=10)
        {
            var userModel = new UserModel();
            var model = userModel.ListAllPaging(page, pageSize);
            ViewBag.page = page;
            return View(model);
        }

        // GET: Admin/NguoiDung/Details/5
        public ActionResult Details(string id)
        {
            var user = new UserModel().GetUserById(id);
            
            return View(user);
        }

        public ActionResult FormEdit(int choose = 0, string searchString = "", int page = 1, int pageSize = 10)
        {
            var userModel = new UserModel();
            IEnumerable<NguoiDung> model = null;
            if (choose == 0)
            {
                model = userModel.ListAllSearch(searchString, page, pageSize);
            }
            else if (choose == 1)
            {
                model = userModel.ListAllSearchID(searchString, page, pageSize);
            }
            else if (choose == 2)
            {
                model = userModel.ListAllSearchName(searchString, page, pageSize);
            }
            else if (choose == 3)
            {
                model = userModel.ListAllSearchAddress(searchString, page, pageSize);
            }
            ViewBag.page = page;
            ViewBag.Search = searchString;
            ViewBag.choose = choose;
            return View(model);
        }
        public ActionResult FormDelete(int choose = 0, string searchString = "", int page = 1, int pageSize = 10)
        {
            var userModel = new UserModel();
            IEnumerable<NguoiDung> model = null;
            if (choose == 0)
            {
                model = userModel.ListAllSearch(searchString, page, pageSize);
            }
            else if (choose == 1)
            {
                model = userModel.ListAllSearchID(searchString, page, pageSize);
            }
            else if (choose == 2)
            {
                model = userModel.ListAllSearchName(searchString, page, pageSize);
            }
            else if (choose == 3)
            {
                model = userModel.ListAllSearchAddress(searchString, page, pageSize);
            }
            ViewBag.page = page;
            ViewBag.Search = searchString;
            ViewBag.choose = choose;
            return View(model);
        }
        // GET: Admin/NguoiDung/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NguoiDung/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NguoiDung/Edit/5
        public ActionResult Edit(string id)
        {
            var user = new UserModel().GetUserById(id);
            return View(user);
        }

        // POST: Admin/NguoiDung/Edit/5
        [HttpPost]
        public ActionResult Edit(NguoiDung lv)
        {

            if (ModelState.IsValid)
            {
                var userModel = new UserModel();
                bool malv = userModel.Update(lv);
                if (malv)
                {
                    return RedirectToAction("FormEdit", "User");
                }

            }
            return View(lv);
        }

        // GET: Admin/NguoiDung/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userModel = new UserModel();
            NguoiDung user = userModel.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);

        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var x = Session["Username"];
            var y = new UserModel().GetUserById(id).TenDangNhap;
            if (!y.Contains(Session["Username"].ToString()))
            {
                var userModel = new UserModel();
                bool check = userModel.Delete(id);
                if (check)
                {
                    return RedirectToAction("FormDelete", "User");
                }
            }
            return View();
        }
    }
}
