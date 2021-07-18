using Hoc_ASP.NET_MVC.Areas.EndUser.Controllers;
using Hoc_ASP.NET_MVC.Models.DAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoc_ASP.NET_MVC.Models.Code
{
    public class SessionHelper
    {

    }

    public class SessionLogin
    {
        public static void Set(UserSession session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }

        public static UserSession Get()
        {
            var session = HttpContext.Current.Session["loginSession"] as UserSession;
            return session;
        }
    }

    public class MyConst
    {
        public const string shoppingCart = "ShoppingCart";
    }

    public class SessionShoppingCart
    {
        public static void Set(List<CartItem> cartItems)
        {
            ShoppingCart cart = HttpContext.Current.Session[MyConst.shoppingCart] as ShoppingCart;
            cart.ListItem = cartItems;
        }
        public static void Add(int id, int? quantity)
        {
            ShoppingCart cart = HttpContext.Current.Session[MyConst.shoppingCart] as ShoppingCart;

            if (cart == null)
            {
                cart = new ShoppingCart();
            }

            // add 
            cart.Add(id, quantity);
            HttpContext.Current.Session[MyConst.shoppingCart] = cart;
        }

        public static void Remove(int idProduct)
        {
            ShoppingCart cart = HttpContext.Current.Session[MyConst.shoppingCart] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
            }

            cart.Remove(idProduct);
            HttpContext.Current.Session[MyConst.shoppingCart] = cart;
        }

        public static ShoppingCart Get()
        {
            ShoppingCart cart = HttpContext.Current.Session[MyConst.shoppingCart] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
            }

            return cart;
        }

        public static void Clear()
        {
            HttpContext.Current.Session[MyConst.shoppingCart] = null;
        }
    }
}