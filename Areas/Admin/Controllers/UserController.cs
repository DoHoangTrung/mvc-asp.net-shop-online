using Hoc_ASP.NET_MVC.Models.Code;
using Hoc_ASP.NET_MVC.Models.DAO;
using Hoc_ASP.NET_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hoc_ASP.NET_MVC.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ActionName ("LoginAction")]
        public ActionResult LoginAction(Account user)
        {
            AccountDAO dao = new AccountDAO();
            if (dao.Login(user))
            {
                SessionHelper.SetSesstionLogin(new UserSession() { UserName = user.nameLogin });
                return RedirectToAction("Index", "Products");
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
    }
}
