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
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var categoryModel = new CategoryModel();
            var model = categoryModel.ListAllPaging(page, pageSize);
            ViewBag.page = page;
            return View(model);
        }
        public ActionResult FormEdit(int choose=0,string searchString="",int page = 1, int pageSize = 10)
        {
            var categoryModel = new CategoryModel();
            IEnumerable<LinhVuc> model=null;
            if (choose == 0)
            {
                model= categoryModel.ListAllSearch(searchString, page, pageSize);
            }
            else if (choose==1)
            {
                model = categoryModel.ListAllSearchID(searchString, page, pageSize);
            }
            else if (choose == 2)
            {
                model = categoryModel.ListAllSearchName(searchString, page, pageSize);
            }
            ViewBag.page = page;
            ViewBag.Search = searchString;
            ViewBag.choose = choose;
            return View(model);
        }
        public ActionResult FormDelete(int choose = 0, string searchString = "", int page = 1, int pageSize = 10)
        {
            var categoryModel = new CategoryModel();
            IEnumerable<LinhVuc> model = null;
            if (choose == 0)
            {
                model = categoryModel.ListAllSearch(searchString, page, pageSize);
            }
            else if (choose == 1)
            {
                model = categoryModel.ListAllSearchID(searchString, page, pageSize);
            }
            else if (choose == 2)
            {
                model = categoryModel.ListAllSearchName(searchString, page, pageSize);
            }
            ViewBag.page = page;
            ViewBag.Search = searchString;
            ViewBag.choose = choose;
            return View(model);
        }
        // GET: Admin/Category/Details/5
        public ActionResult Details(string id)
        {
            var category = new CategoryModel().GetCategoryById(id);
            return View(category);
        }

        // GET: Admin/Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LinhVuc lv)
        {
            
            if (ModelState.IsValid)
            {
                var categoryModel = new CategoryModel();
                
                bool r = categoryModel.Check(lv);
                if(!r)
                {
                    bool malv = categoryModel.Insert(lv);
                    if (malv)
                    {
                        return RedirectToAction("Index", "Category");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Trùng mã khóa");
                }
                
            }
            return View(lv);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(string id)
        {
            var category = new CategoryModel().GetCategoryById(id);
            return View(category);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(LinhVuc lv)
        {

            if (ModelState.IsValid)
            {
                var categoryModel = new CategoryModel();
                    bool malv = categoryModel.Update(lv);
                    if (malv)
                    {
                        return RedirectToAction("FormEdit", "Category");
                    }

            }
            return View(lv);
        }

        // GET: Admin/Category/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoryModel = new CategoryModel();
            LinhVuc linhVuc = categoryModel.GetCategoryById(id);
            ViewBag.EntityChild = new ProductModel().GetProductsByCategory(id);
            if (linhVuc == null)
            {
                return HttpNotFound();
            }
            return View(linhVuc);

        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, int check)
        {
            var categoryModel = new CategoryModel();
            if(check==1)
            {
                bool c = categoryModel.Delete(id);
                if (c)
                {
                    return RedirectToAction("FormDelete", "Category");
                }
            }
            else
            {
                var product = new ProductModel();
                IEnumerable<Product> ls = product.GetProductsByCategory(id);
                product.DeleteList(ls);
                bool c = categoryModel.Delete(id);
                
                return RedirectToAction("FormDelete", "Category");
            }
            
            return View();
        }


        // POST: Admin/LinhVucs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    LinhVuc linhVuc = await db.LinhVucs.FindAsync(id);
        //    db.LinhVucs.Remove(linhVuc);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
