using Model.EF;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.DAO
{
    public class NewDao
    {
        SachDbContext db = null;
        public NewDao()
        {
            db = new SachDbContext();
        }
        public IEnumerable<News> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<News> model = db.News;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Title.Contains(searchString));

            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);

        }
        public IEnumerable<NewsViewModel> ListAllByTag(string searchString, int page, int pageSize)
        {
            var news = (from a in db.News
                        join b in db.NewsType
                        on a.TypeID equals b.ID
                        join c in db.Admin
                        on a.Created equals c.ID
                        select new NewsViewModel
                        {
                           news=a,
                           NameAdmin=c.UserName,
                           NameType = b.Name
                        });
            if (!string.IsNullOrEmpty(searchString))
            {
                news =  news.Where(x => x.news.Title.Contains(searchString)||x.NameType.Contains(searchString));

            }
            return news.OrderByDescending(x => x.news.CreatedDate).ToPagedList(page, pageSize);
    }

    public bool AddNew(News entity,long u)
        {
            try
            {
                var news = new News();
                news.ID = entity.ID;
                news.Title = entity.Title;
                news.Created = u;
                news.CreatedDate = DateTime.Now;
                news.isPublic = true;
                news.Author = entity.Author;
                news.Content = entity.Content;
                news.isHomePage = entity.isHomePage;
                news.Image = entity.Image;
                news.TypeID = entity.TypeID;
                db.News.Add(news);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public News FindID(long id)
        {
            return db.News.Find(id);
        }

        public bool EditNew(News entity)
        {
            try
            {
                var news = FindID(entity.ID);
                news.ID = entity.ID;
                news.Title = entity.Title;
                
                news.CreatedDate = DateTime.Now;
                news.isPublic = true;
                news.Author = entity.Author;
                news.Content = entity.Content;
                news.isHomePage = entity.isHomePage;
                news.Image = entity.Image;
                news.TypeID = entity.TypeID;
             
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteNew(long id)
        {
            try
            {
                var slide = db.News.Find(id);
                db.News.Remove(slide);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool ChangeStatus(long id)
        {
            var slide = db.News.Find(id);
            slide.isPublic = !slide.isPublic;
            db.SaveChanges();
            return (bool)slide.isPublic;
        }
        public News ViewDetail(int id)
        {
            return db.News.Find(id);
        }
        public List<string> Listsearch(string search)
        {
            var model = (from a in db.News
                        join b in db.NewsType
                        on a.TypeID equals b.ID
                        join c in db.Admin
                        on a.Created equals c.ID
                        select new NewsViewModel
                        {
                            news = a,
                            NameAdmin = c.UserName,
                            NameType = b.Name
                        });
            var ls = (from x in model
                      where x.news.Title.Contains(search)
                      select x.news.Title).ToList();
            var lsNameType = (from x in model
                            where x.NameType.Contains(search)
                            select x.NameType).AsEnumerable();
            ls.AddRange(lsNameType);
            return ls;
        }

    }
}

