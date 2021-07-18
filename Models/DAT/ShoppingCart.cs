using Hoc_ASP.NET_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoc_ASP.NET_MVC.Models.DAT
{
    public class ShoppingCart
    {
        public List<CartItem> ListItem { get; set; }

        public decimal TotalCash { get {
                decimal result = 0;
                foreach (var item in ListItem)
                {
                    result += item.totalPrice;
                }

                return result;
            } }

        public ShoppingCart()
        {
            ListItem = new List<CartItem>();
        }

        public void Add(int id, int? quantity)
        {
            CartItem tmp = new CartItem(id, quantity);

            bool exist = false;
            foreach (var item in ListItem)
            {
                //if exist, increase item's quatity
                if (item.idProduct == tmp.idProduct)
                {
                    exist = true;
                    item.quantity += tmp.quantity;
                    return;
                }
            }

            if (!exist)
            {
                ListItem.Add(tmp);
            }
        }
        public void Add(CartItem tmp)
        {
            if (tmp != null)
            {
                bool exist = false;
                foreach (var item in ListItem)
                {
                    //if exist, increase item's quatity
                    if (item.idProduct == tmp.idProduct)
                    {
                        exist = true;
                        item.quantity += tmp.quantity;
                        return;
                    }
                }

                if (!exist)
                {
                    ListItem.Add(tmp);
                }
            }
        }

        public void Remove(int id)
        {
            foreach (var item in ListItem)
            {
                if(item.idProduct == id)
                {
                    ListItem.Remove(item);
                    break;
                }
            }
        }

        public void Remove(CartItem item)
        {
            if (item != null)
            {
                ListItem.Remove(item);
            }
        }
    }
}