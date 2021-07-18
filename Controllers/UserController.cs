
using Hoc_ASP.NET_MVC.Models.Code;
using Hoc_ASP.NET_MVC.Models.DAO;
using Hoc_ASP.NET_MVC.Models.Entity;
using System.Web.Mvc;

namespace Hoc_ASP.NET_MVC.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ActionName ("LoginAction")]
        public ActionResult Login(Account user)
        {
            AccountDAO dao = new AccountDAO();
            string typeAccount = dao.Login(user);
            if (!string.IsNullOrEmpty(typeAccount))
            {
                SessionLogin.Set(new UserSession() { UserName = user.userName });
                if (typeAccount == "admin")
                {
                    return RedirectToAction("Index", "Products", new { area = "Admin" });
                }
                else //if(typeAccount == "endUser")
                {
                    return RedirectToAction("Index", "Products", new { area = "EndUser" });
                }
            }
            else
                return View();
        }

        public ActionResult Logout()
        {
            SessionLogin.Set(null);

            return RedirectToAction("Login", "User", new { area = "" });
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Account newAcc)
        {
            if (ModelState.IsValid)
            {
                AccountDAO accountDAO = new AccountDAO();
                int rowAffected = accountDAO.Insert(newAcc);
                if (rowAffected > 0)
                {
                    return RedirectToAction("Login", "User", new { area = "" });
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}