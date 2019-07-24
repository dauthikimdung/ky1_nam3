using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models.Framework;

namespace Models
{
    public class TaiKhoanModel
    {
        private BookShopDbContext context;
        /// <summary>
        /// Contructor
        /// </summary>
        public TaiKhoanModel()
        {
            context = new BookShopDbContext();
        }
        public bool Login(string user, string pass)
        {
            object[] sqlParams =
            {
                new SqlParameter("@username",user),
                new SqlParameter("@password",pass)

            };
            var res = context.Database.SqlQuery<bool>("sp_Login @username, @password", sqlParams).SingleOrDefault();
            return res;
        }
    }
}
