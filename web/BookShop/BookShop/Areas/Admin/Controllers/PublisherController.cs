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
    public class PublisherController : Controller
    {
        // GET: Admin/Publisher
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var publishModel = new PublisherModel();
            var model = publishModel.ListAllPaging(page, pageSize);
            ViewBag.page = page;
            return View(model);
        }
        public ActionResult FormEdit(int choose = 0, string searchString = "", int page = 1, int pageSize = 10)
        {
            var publishModel = new PublisherModel();
            IEnumerable<NhaXuatBan> model = null;
            if (choose == 0)
            {
                model = publishModel.ListAllSearch(searchString, page, pageSize);
            }
            else if (choose == 1)
            {
                model = publishModel.ListAllSearchID(searchString, page, pageSize);
            }
            else if (choose == 2)
            {
                model = publishModel.ListAllSearchName(searchString, page, pageSize);
            }
            else if (choose == 3)
            {
                model = publishModel.ListAllSearchAddress(searchString, page, pageSize);
            }
            ViewBag.page = page;
            ViewBag.Search = searchString;
            ViewBag.choose = choose;
            return View(model);
        }
        public ActionResult FormDelete(int choose = 0, string searchString = "", int page = 1, int pageSize = 10)
        {
            var publishModel = new PublisherModel();
            IEnumerable<NhaXuatBan> model = null;
            if (choose == 0)
            {
                model = publishModel.ListAllSearch(searchString, page, pageSize);
            }
            else if (choose == 1)
            {
                model = publishModel.ListAllSearchID(searchString, page, pageSize);
            }
            else if (choose == 2)
            {
                model = publishModel.ListAllSearchName(searchString, page, pageSize);
            }
            else if (choose == 3)
            {
                model = publishModel.ListAllSearchAddress(searchString, page, pageSize);
            }
            ViewBag.page = page;
            ViewBag.Search = searchString;
            ViewBag.choose = choose;
            return View(model);
        }
        // GET: Admin/Publisher/Details/5
        public ActionResult Details(string id)
        {
            var publisher = new PublisherModel().GetPublisherById(id);
            return View(publisher);
        }

        // GET: Admin/Publisher/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhaXuatBan nxb)
        {

            if (ModelState.IsValid)
            {
                var publisherModel = new PublisherModel();

                bool r = publisherModel.Check(nxb);
                if (!r)
                {
                    bool malv = publisherModel.Insert(nxb);
                    if (malv)
                    {
                        return RedirectToAction("Index", "Publisher");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Trùng mã khóa");
                }

            }
            return View(nxb);
        }

        // GET: Admin/Publisher/Edit/5
        public ActionResult Edit(string id)
        {
            var publisher = new PublisherModel().GetPublisherById(id);
            return View(publisher);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(NhaXuatBan publisher)
        {

            if (ModelState.IsValid)
            {
                var publisherModel = new PublisherModel();
                bool check = publisherModel.Update(publisher);
                if (check)
                {
                    return RedirectToAction("FormEdit", "Publisher");
                }

            }
            return View(publisher);
        }


        // GET: Admin/Publisher/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var publisherModel = new PublisherModel();
            NhaXuatBan publisher = publisherModel.GetPublisherById(id);
            ViewBag.EntityChild = new ProductModel().GetProductsByPublisher(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);

        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id,int check)
        {
            var publisherModel = new PublisherModel();
            if (check == 1)
            {
                bool c = publisherModel.Delete(id);
                if (c)
                {
                    return RedirectToAction("FormDelete", "Publisher");
                }
            }
            else
            {
                var product = new ProductModel();
                IEnumerable<Product> ls = product.GetProductsByPublisher(id);
                product.DeleteList(ls);
                bool c = publisherModel.Delete(id);
                
                return RedirectToAction("FormDelete", "Publisher");
            }
            return View();
        }
    }
}
