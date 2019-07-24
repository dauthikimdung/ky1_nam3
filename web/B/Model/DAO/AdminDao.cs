using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class AdminDao
    {
        SachDbContext db = null;
        public AdminDao()
        {
            db = new SachDbContext();
        }
        public List<Admin> ListAll()
        {
            return db.Admin.Where(x => x.Status == true).ToList();
        }
        public bool LoginAdmin(string user, string pass)
        {
            var ad = db.Admin.SingleOrDefault(x => x.UserName == user && x.PassWord == pass);
            if (ad == null)
            {
                return false;
            }
            return true;
        }
    }
}
