using Hoc_ASP.NET_MVC.Models.DAO;
using Hoc_ASP.NET_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoc_ASP.NET_MVC.Models.DAT
{
    public class CartItem
    {
        public int idProduct { get; set; }

        public int? quantity { get; set; }

        public double? discount { get; set; }

        public Product product
        {
            get
            {
                ProductDAO pDao = new ProductDAO();
                return pDao.GetByID(this.idProduct);
            }
        }

        public decimal totalPrice
        {
            get
            {
                if (product != null)
                {
                    return (decimal)product.price * (quantity.GetValueOrDefault());
                }
                else
                    return 0;
            }
        }

        public CartItem(int id, int? quantity)
        {
            this.idProduct = id;
            this.quantity = quantity;
        }

        public CartItem() { }

    }
}