using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B.Areas.admins.Controllers
{
    public class AuthorController : Controller
    {
       
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            var dao = new AuthorDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Type = new SelectList(new AuthorDao().Form());
            var model = new AuthorDao().ViewDetail(id);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Author bk)
        {

            if (ModelState.IsValid)
            {

                var dao = new AuthorDao();

                var result = dao.Update(bk);
                if (result)
                {
                    SetAlert("Cập nhật sách thành công", "success");

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
            ViewBag.Type = new SelectList(new AuthorDao().Form());
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Author us)
        {
            if (ModelState.IsValid)
            {
                var dao = new AuthorDao();
                var id = dao.addAuthor(us);
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
       
        public ActionResult Delete(int id)
        {

            var res = new AuthorDao().Delete(id);

            if (res)
            {

                SetAlert("xóa thành công", "success");

                return RedirectToAction("Index");
            }
            else
            {
                SetAlert("xóa không thành công", "error");

            }

            return RedirectToAction("Index");


        }
        
        public ActionResult SetNull(int id)
        {

            var res = new AuthorDao().SetNull(id);

            if (res)
            {
                
                 SetAlert("xóa thành công", "success");

                 return RedirectToAction("Index");
            }
               else
            {
                  SetAlert("xóa không thành công", "error");

           }
            
            return RedirectToAction("Index");


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
            var data = new AuthorDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);


        }
    }
}   