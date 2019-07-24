using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMVC.Models;
using BookMVC.Entities;
using System.Data.SqlClient;
using System.Data;

namespace BookMVC.Dao
{
     public class DomainDao
     {
          public BookMVCDbContext db ;
          public DomainDao()
          {
              db = new BookMVCDbContext();
          }
          //public string connectionString = "Data Source=KATSUKID ;Initial Catalog=BookShop;integrated security=true;Trusted_Connection=True;";
          public List<BookViewModel> Filtered(long? author, long? bookcategory, DateTime? publishdate, decimal? lowprice, decimal? highprice)
          {
               if (author == 0) author = null;
               if (bookcategory == 0) bookcategory = null;
               if (highprice < lowprice || highprice == 0) highprice = lowprice = null;
               bool check = false;
               string query = "SELECT b.ID AS ID,b.Name AS Name,a.Name AS Author, r.Name AS Released,"
                              + "p.Name AS Publisher, b.CategoryID AS CategoryID,"
                              + "b.Price AS Price,b.PromotionPrice AS PromotionPrice,"
                              + "b.ViewCount AS ViewCount,b.Inventory AS Inventory,"
                              + "b.Author AS AuthorID, b.Released AS ReleasedID, b.Publisher AS PublisherID,"
                              + "b.Buys AS Buys, b.NumberPage AS NumberPage, b.[Weight] AS [Weight],"
                              + "b.[Image] AS [Image], b.PublishDate AS PublishDate, b.[Description] AS [Description] "
                              + "FROM Book AS b "
                              + "JOIN Author AS a ON b.Author=a.ID "
                              + "JOIN BookCategory AS bc ON b.CategoryID=bc.ID "
                              + "JOIN Publisher AS p ON b.Publisher = p.ID "
                              + "JOIN Publisher AS r ON b.Released = r.ID ";
               if (author != null || bookcategory != null || publishdate != null || (lowprice != null && highprice != null))
                    query += " WHERE";
               //     Nếu có yêu cầu tác giả
               if (author != null)
               {
                    check = true;
                    query += " b.Author = @author";
               }
               //     Nếu có yêu cầu loại sách
               if (bookcategory != null)
               {
                    if (check)
                    {
                         query += " AND";
                    }
                    else
                    {
                         check = true;
                    }
                    query += " b.CategoryID = @bookcategory";
               }
               //     Nếu có yêu cầu ngày xuất bản
               if (publishdate != null)
               {
                    if (check)
                    {
                         query += " AND";
                    }
                    else
                    {
                         check = true;
                    }
                    query += " b.PublishDate > @publishdate";
               }
               //     Nếu có yêu cầu khoảng giá
               if (lowprice != null && highprice != null)
               {
                    if (check)
                    {
                         query += " AND";
                    }
                    else
                    {
                         check = true;
                    }
                    query += " b.PromotionPrice BETWEEN @lowprice AND @highprice";
               }
               bool check2 = false;
               var pra_author = new[] { new SqlParameter("@author", author) };
               var pra_bookcategory = new[] { new SqlParameter("@bookcategory", bookcategory) };
               var pra_publishdate = new[] { new SqlParameter("@publishdate", publishdate) };
               var pra_lowprice = new[] { new SqlParameter("@lowprice", lowprice) };
               var pra_highprice = new[]{ new SqlParameter("@highprice", highprice) };
               SqlParameter[] parameters = new SqlParameter[1];
               if (author != null)
               {
                    check2 = true;
                    parameters = pra_author;
               }
               if(bookcategory != null)
               {
                    if (check2)
                         parameters = parameters.Concat(pra_bookcategory).ToArray();
                    else
                    {
                         check2 = true;
                         parameters = pra_bookcategory;
                    }
               }
               if (publishdate != null)
               {
                    if (check2)
                         parameters = parameters.Concat(pra_publishdate).ToArray();
                    else
                    {
                         check2 = true;
                         parameters = pra_publishdate;
                    }
               }
               if (lowprice != null && highprice != null)
               {
                    if (check2)
                    {
                         parameters = parameters.Concat(pra_lowprice).ToArray();
                         parameters = parameters.Concat(pra_highprice).ToArray();
                    }                         
                    else
                    {
                         check2 = true;
                         parameters = pra_lowprice;
                         parameters = parameters.Concat(pra_highprice).ToArray();
                    }
               }

               var lsBook = db.Database.SqlQuery<BookViewModel>(query, parameters);
               

               return lsBook.ToList();
          }
     }
}