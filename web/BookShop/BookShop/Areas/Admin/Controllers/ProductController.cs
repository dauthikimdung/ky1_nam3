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
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var productModel = new ProductModel();
            var model = productModel.ListAllPaging(page, pageSize);
            
            
            ViewBag.page = page;
            return View(model);
        }
        public ActionResult FormEdit(int choose = 0, string searchString = "", int page = 1, int pageSize = 10)
        {
            var productModel = new ProductModel();
            IEnumerable<Product> model = null;
            if (choose == 0)
            {
                model = productModel.ListAllSearch(searchString, page, pageSize);
            }
            else if (choose == 1)
            {
                model = productModel.ListAllSearchID(searchString, page, pageSize);
            }
            else if (choose == 2)
            {
                model = productModel.ListAllSearchName(searchString, page, pageSize);
            }
            else if (choose == 3)
            {
                model = productModel.ListAllSearchPublisher(searchString, page, pageSize);
            }
            else if (choose == 4)
            {
                model = productModel.ListAllSearchCatagory(searchString, page, pageSize);
            }
            ViewBag.page = page;
            ViewBag.Search = searchString;
            ViewBag.choose = choose;
            return View(model);
        }
        public ActionResult FormDelete(int choose = 0, string searchString = "", int page = 1, int pageSize = 10)
        {
            var productModel = new ProductModel();
            IEnumerable<Product> model = null;
            if (choose == 0)
            {
                model = productModel.ListAllSearch(searchString, page, pageSize);
            }
            else if (choose == 1)
            {
                model = productModel.ListAllSearchID(searchString, page, pageSize);
            }
            else if (choose == 2)
            {
                model = productModel.ListAllSearchName(searchString, page, pageSize);
            }
            else if (choose == 3)
            {
                model = productModel.ListAllSearchPublisher(searchString, page, pageSize);
            }
            else if (choose == 4)
            {
                model = productModel.ListAllSearchCatagory(searchString, page, pageSize);
            }
            ViewBag.page = page;
            ViewBag.Search = searchString;
            ViewBag.choose = choose;
            return View(model);
        }
        // GET: Admin/Product/Details/5
        public ActionResult Details(string id)
        {
            var product = new ProductModel().GetProductById(id);
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.NXB = new PublisherModel().ListAll();
            ViewBag.LinhVuc = new CategoryModel().ListAll();
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            product.AnhBiaSP = product.AnhBiaSP.Replace("files/", "");
            ViewBag.NXB = new PublisherModel().ListAll();
            ViewBag.LinhVuc = new CategoryModel().ListAll();
            if (ModelState.IsValid)
            {
                var productModel = new ProductModel();

                bool r = productModel.Check(product);
                if (!r)
                {
                    product.MaLinhVuc = new CategoryModel().GetCategoryByName(product.MaLinhVuc).MaLinhVuc;
                    product.MaNXB = new PublisherModel().GetPublisherByName(product.MaNXB).MaNXB;
                    bool malv = productModel.Insert(product);
                    if (malv)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Trùng mã khóa");
                }

            }
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.NXB = new PublisherModel().ListAll();
            ViewBag.LinhVuc = new CategoryModel().ListAll();
            var product = new ProductModel().GetProductById(id);
            //product.MaLinhVuc = new CategoryModel().GetCategoryById(product.MaLinhVuc).TenLinhVuc;
            //product.MaNXB = new PublisherModel().GetPublisherById(product.MaNXB).TenNXB;
            return View(product);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Product lv)
        {
            ViewBag.NXB = new PublisherModel().ListAll();
            ViewBag.LinhVuc = new CategoryModel().ListAll();
            //lv.MaLinhVuc = new CategoryModel().GetCategoryByName(lv.MaLinhVuc).MaLinhVuc;
            //lv.MaNXB = new PublisherModel().GetPublisherByName(lv.MaNXB).MaNXB;
            if (ModelState.IsValid)
            {
                var productModel = new ProductModel();

                bool malv = productModel.Update(lv);
                if (malv)
                {
                    return RedirectToAction("FormEdit", "Product");
                }

            }
            return View(lv);
        }

        // GET: Admin/Product/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productModel = new ProductModel();
            Product product = productModel.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);

        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var productModel = new ProductModel();
            bool check = productModel.Delete(id);
            if (check)
            {
                return RedirectToAction("FormDelete", "Product");
            }
            return View();
        }
    }
}
