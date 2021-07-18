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
        public string Login(Account user)
        {
            try
            {
                string type = db.Database.SqlQuery<string>("EXEC dbo.Login @userName,@passWord", new SqlParameter[]
                {
                    new SqlParameter("userName",user.userName),
                    new SqlParameter("passWord",user.passWord),
                }).FirstOrDefault();

                return type;
            }
            catch
            {
                return string.Empty;
            }

        }

        public int Insert(Account newUser)
        {
            int rowAffected = 0;

            if(newUser != null)
            {
                try
                {
                    if(newUser.typeId == null)
                    {
                        newUser.typeId = 2;
                    }
                    db.Accounts.Add(newUser);
                    rowAffected = db.SaveChanges();
                }
                catch (Exception e)
                {
                    rowAffected = -1;
                }
                
            }

            return rowAffected;
        }
    }
}