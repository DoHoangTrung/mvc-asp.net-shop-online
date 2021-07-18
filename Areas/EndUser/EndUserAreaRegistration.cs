using System.Web.Mvc;

namespace Hoc_ASP.NET_MVC.Areas.EndUser
{
    public class EndUserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EndUser";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            var route = context.MapRoute(
                "EndUser_default",
                "EndUser/{controller}/{action}/{id}",
                new { controller = "Products", action = "Index", id = UrlParameter.Optional }//,new[] { "Hoc_ASP.NET_MVC.Areas.EndUser.Controllers" }
            );
        }
    }
}