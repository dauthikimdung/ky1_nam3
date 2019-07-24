using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B.Areas.admins.Controllers
{
    public class CateGoryController : Controller
    {
        // GET: admins/CateGory
        public ActionResult Index(string search,int page=1,int pagesize=4)
        {
            IEnumerable<Category> model;
            var dao = new CategoryDao();
            ViewBag.SearchString = search;
            model = dao.ListAllpage(search, page, pagesize);
            return View(model);
        }
        public JsonResult ChangeStatus (int id)
        {
            var dao = new CategoryDao();
            return Json(new { status = dao.ChangeStatus(id) });
        }
        public void SetAlert(string message, string type)
        {
            //Giống ViewBag
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "Warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
        public JsonResult ListName(string q)
        {
            var data = new CategoryDao().Listsearch(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
           
            var model = new CategoryDao().ViewDetail(id);
           
            
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Category bk)
        {

            if (ModelState.IsValid)
            {

                var dao = new CategoryDao();

               
                var result = dao.Update(bk);
                if (result)
                {
                    SetAlert("Cập nhật  thành công", "success");

                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Cập nhật không thành công", "error");

                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Category us)
        {
            if (ModelState.IsValid)
            {
                var creatby = Session["UserName"] as string;
                var dao = new CategoryDao();
                var id = dao.add(us,creatby);
                if (id)
                {
                    SetAlert("Thêm mới thành công", "success");

                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Thêm không thành công", "error");

                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            var res = new CategoryDao().Delete(id);

            if (res)
            {
                return Json(new { status = true });
            }
            else
            {
                return Json(new { status = false });
            }


        }
    }
}