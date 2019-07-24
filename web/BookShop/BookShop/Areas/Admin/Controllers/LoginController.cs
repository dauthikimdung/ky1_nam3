
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.Areas.Admin.Code;
using BookShop.Areas.Admin.Models;
using BookShop.Common;

namespace BookShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index2(LoginModel model)
        //{
        //    var result = new TaiKhoanModel().Login(model.UserName, model.Password);
        //    if(result&&ModelState.IsValid)
        //    {
        //        SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
        //    }
        //    return View(model);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            
            ViewBag.message = null;
            var userModel = new UserModel();
            var result = userModel.Login(model.UserName, model.Password);
            if(result && ModelState.IsValid )
            {
                Session["Username"] = model.UserName;
                Session["Password"] = model.Password;
                Session["Name"] = new UserModel().GetUserByUserName(model.UserName).HoTenKH;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "Thông tin đăng nhập không chính xác";
                ModelState.AddModelError("", "Thông tin đăng nhập không chính xác");
            }
            return View("Index");
        }
    }
}