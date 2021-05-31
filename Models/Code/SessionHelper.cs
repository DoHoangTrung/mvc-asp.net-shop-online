using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoc_ASP.NET_MVC.Models.Code
{
    public class SessionHelper
    {
        public static void SetSesstionLogin(UserSession session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }

        public static UserSession GetSessionLogin()
        {
            var session = HttpContext.Current.Session["loginSession"] as UserSession;
            return session;
        }

    }
}