using Hoc_ASP.NET_MVC.Models.Code;
using Hoc_ASP.NET_MVC.Models.DAO;
using Hoc_ASP.NET_MVC.Models.DAT;
using Hoc_ASP.NET_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hoc_ASP.NET_MVC.Areas.EndUser.Controllers
{

    public class CartController : Controller
    {
        //Get: EndUser/Cart/Add/1?quatity=
        public ActionResult Add(int id, int? quantity)
        {
            SessionShoppingCart.Add(id, quantity);
            return Redirect(HttpContext.Request.UrlReferrer.ToString());
        }

        public ActionResult Remove(int id)
        {
            SessionShoppingCart.Remove(id);

            return View("Show");

        }

        public ActionResult Show()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult Update(string model)
        {
            bool status = true;

            ProductDAO dao = new ProductDAO();

            List<CartItem> cartItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CartItem>>(model);
            if (cartItems == null)
                status = false;

            SessionShoppingCart.Set(cartItems);

            return PartialView("~/Areas/EndUser/Views/Shared/TableCartItem.cshtml");
        }

        //Get: /EndUser/Cart/Checkout
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]

        public JsonResult CheckOut(string transaction)
        {
            bool status = false;
            TransactionDAO tranDAO = new TransactionDAO();

            Transaction bill = Newtonsoft.Json.JsonConvert.DeserializeObject<Transaction>(transaction);

            ShoppingCart cart = SessionShoppingCart.Get();
            int rowAffected = 0;
            if (cart != null)
            {
                rowAffected = tranDAO.Insert(bill, cart.ListItem);
                if(rowAffected> 0)
                {
                    status = true;
                    SessionShoppingCart.Clear();
                }
            }

            return Json(new
            {
                status = status,
            }) ;
        }

    }
}
