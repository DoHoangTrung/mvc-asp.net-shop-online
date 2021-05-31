using Hoc_ASP.NET_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hoc_ASP.NET_MVC.Models.DAO
{
    public class AccountDAO
    {
        private ShopContext db;

        public AccountDAO()
        {
            db = new ShopContext();
        }
        public bool Login(Account user)
        {
            int count = db.Database.SqlQuery<int>("EXEC Login @userName,@passWord", new SqlParameter[]
            {
                new SqlParameter("userName",user.nameLogin),
                new SqlParameter("passWord",user.passWord),
            }).FirstOrDefault();

            if (count > 0) 
                return true;
            else 
                return false;
        }
    }
}