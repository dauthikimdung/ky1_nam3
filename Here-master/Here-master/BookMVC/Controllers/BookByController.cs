using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMVC.Models;
using BookMVC.Entities;
using BookMVC.Dao;
using System.Data.SqlClient;

namespace BookMVC.Controllers
{
    public class BookByController : Controller
    {
        // GET: BookByCategory
        private void SetViewBag()
          {
               ViewBag.AuthorLocal = new AuthorDao().ListLocal();
               ViewBag.AuthorForgery = new AuthorDao().ListForgery();
               ViewBag.Category = new CategoryDao()._ListAll();
               ViewBag.lsBook = new BookDao()._ListAll();
          }
          public ActionResult Index()
          {
               SetViewBag();
               var lsBook = new DomainDao().Filtered(null, null, null, null, null);
               return View(lsBook);
          }
          
          public ActionResult FilteredByBookCate(long? select_bookcate)
          {
               var lsBook = new DomainDao().Filtered(null, select_bookcate, null, null, null);
               SetViewBag();
               return View("Index",lsBook);
          }
          public ActionResult FilteredByAuthor(long? select_author)
          {
               var lsBook = new DomainDao().Filtered(select_author, null, null, null, null);
               SetViewBag();
               return View("Index", lsBook);
          }
          public ActionResult FilteredByPublisher(long? select_publisher)
          {
               var lsBook = new DomainDao().Filtered(null, null, null, null, null);
               SetViewBag();
               return View("Index", lsBook);
          }
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Filtered(long? select_bookcate, long? select_author, DateTime? publishdate, decimal? lowprice, decimal? highprice)
          {
               var lsBook = new DomainDao().Filtered(select_author, select_bookcate, publishdate, lowprice, highprice);
               return PartialView(lsBook);
          }
    }
}