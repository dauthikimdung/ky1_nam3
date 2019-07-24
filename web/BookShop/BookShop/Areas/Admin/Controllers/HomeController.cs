using BookShop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile(string userName)
        {
            UserModel userModel = new UserModel();
            var model = userModel.GetUserByUserName(Session["Username"].ToString());
            return View(model);

            //return View(model)
        }
    }
}