using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using PagedList;
using Model.EF;
namespace B.Areas.admins.Controllers
{
    public class NewController : Controller
    {
        // GET: admins/Book
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            var dao = new NewDao();
            var model = dao.ListAllByTag(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
          
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.B = new NewDao().ViewDetail(id);
            var B = new NewDao().ViewDetail(id);
            SetViewBag(B.TypeID);
           
            return View(B);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(News bk)
        {

            if (ModelState.IsValid)
            {

                var dao = new NewDao();

                var result = dao.EditNew(bk);
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

            SetViewBag();
          

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(News us)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewDao();
                var u = (long)Session["UserName"];
                var id = dao.AddNew(us,u);
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

            var res = new NewDao().DeleteNew(id);

            if (res)
            {
                return Json(new { status = true });
            }
            else
            {
                return Json(new { status = false });
            }


        }
        //Lấy ra thông tin dropdownList
        public void SetViewBag(long? selectID = null)
        {
            var dao = new NewTypeDao();
            ViewBag.TypeID = new SelectList(dao.ListAll(), "ID", "Name", selectID);
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
        public JsonResult ChangeStatus(int id)
        {
            var result = new NewDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        public JsonResult ListName(string q)
        {
            var data = new NewDao().Listsearch(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }

}

