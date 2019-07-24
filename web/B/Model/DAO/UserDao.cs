using System;
using System.Collections.Generic;
using System.Linq;
using Model.EF;
using PagedList;
using Com;
namespace Model.DAO
{
    public  class UserDao
    {
        SachDbContext db = null;
        public UserDao()
        {
            db = new SachDbContext();
        }
        public bool Insert(User entity)
        {
            try
            {
                var user = new User();
                user.Name = entity.Name;

                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.Password = entity.Password;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                user.Status = true;
                db.User.Add(user);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

  
        public IEnumerable<User>ListAllPaging(string searchString, int page,int pageSize)
        {
            IQueryable<User> model = db.User;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString)||x.UserName.Contains(searchString));

            }
            return model.OrderByDescending(x =>x.Name).ToPagedList(page, pageSize);
           
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.ID);
                user.Name = entity.Name;
                user.Phone = entity.Phone;
                user.Password = entity.Password;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public User GetById(string userName )
        {
            return db.User.SingleOrDefault(x=>x.Name == userName);
        }
        public User ViewDetail(int id)
        {
            return db.User.Find(id);
        }

        //public int Login(string userName, string passWord)
        //{
        //    var result = db.User.SingleOrDefault(x => x.UserName == userName);
        //    if (result == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        if (result.GroupID == ComConstant.ADMIN_GROUP || result.GroupID == ComConstant.MOD_GROUP)
        //        {
        //            if (result.Status == false)
        //            {
        //                return -1;
        //            }
        //            else
        //            {
        //                if (result.Password == passWord)
        //                    return 1;
        //                else
        //                    return -2;
        //            }
        //        }
        //        else
        //        {
        //            return -3;
        //        }
                
        //    }
        //}
        public List<string> GetListCredential(string userName)
        {
            var user = db.User.Single(x => x.UserName == userName);
            var data = (from a in db.Credential
                        join b in db.UserGroup on a.UserGroupID equals b.ID
                        join c in db.Role on a.RoleID equals c.ID
                        where b.ID == user.GroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }
        public int Delete (long id,long us)
        {
            try
            {
                var user = db.User.Find(id);
                if(id!=us)
                {
                    db.User.Remove(user);
                    db.SaveChanges();
                    return 1;
                }
               else
                {
                    return 0;
                }
                

            }catch(Exception)
            {
                return -1;
            }
           
           
        }

       public bool ChangeStatus(long id)
        {
            var user = db.User.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return (bool)user.Status;
        }
        public User TakeUser(string EmailOrUserName,string password)
        {
            var user = db.User.Where(x => x.UserName == EmailOrUserName && x.Password == password).SingleOrDefault();
            return user;
        }
     
       public bool Login(string UserName,string Password)
        {
            var rs = db.User.Count(x => x.UserName == UserName && x.Password == Password);
            if (rs > 0) return true;
          
            return false;
        }
        public List<User> ListAll()
        {
            return db.User.ToList();
        }
        public List<string> Listsearch(string search)
        {
           
            var ls = (from x in db.User
                      where x.UserName.Contains(search)
                      select x.UserName).ToList();
            var lsUserName= (from x in db.User
                             where x.Name.Contains(search)
                             select x.Name).AsEnumerable();
            ls.AddRange(lsUserName);
            return ls;
        }
    }
}

