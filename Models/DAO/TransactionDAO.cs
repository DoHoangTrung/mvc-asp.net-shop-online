using Hoc_ASP.NET_MVC.Models.DAT;
using Hoc_ASP.NET_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoc_ASP.NET_MVC.Models.DAO
{
    public class TransactionDAO
    {
        private ShopContext db;
        public TransactionDAO()
        {
            db = new ShopContext();
        }

        public int Insert(Transaction bill, List<Order> orders)
        {
            int rowAffected = 0;

            bill.statusId = 1;

            bill.Orders = orders;

            db.Transactions.Add(bill);
            rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public int Insert(Transaction bill, List<CartItem> cartItems)
        {
            int rowAffected = 0;

            bill.statusId = 1;
            bill.createAt = DateTime.Now;

            List<Order> orders = new List<Order>();
            foreach (var item in cartItems)
            {
                Order tmp = new Order();
                tmp.idProduct = item.idProduct;
                tmp.quantity = item.quantity;
                tmp.discount = item.discount;

                orders.Add(tmp);
            }
            bill.Orders = orders;

            db.Transactions.Add(bill);
            rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public IEnumerable<Transaction> Get()
        {
            return db.Transactions.OrderBy(t => t.createAt);
        }

        public IEnumerable<Transaction> GetWaitBills()
        {
            return db.Transactions.Where(t => t.statusId == 1).OrderBy(t=>t.createAt);
        }
        public IEnumerable<Transaction> GetTransportingBills()
        {
            return db.Transactions.Where(t => t.statusId == 2).OrderBy(t => t.createAt);
        }
        public IEnumerable<Transaction> GetPaidBills()
        {
            return db.Transactions.Where(t => t.statusId == 3).OrderBy(t => t.createAt);
        }

        public double TotalCash(int id)
        {
            Transaction bill = db.Transactions.Find(id);

            double total = 0;
            foreach (var item in bill.Orders)
            {
                total += item.Product.price.GetValueOrDefault() * item.quantity.GetValueOrDefault() * (1 - item.discount.GetValueOrDefault());
            }

            return total;
        }

        public int TotalQuantity(int id)
        {
            Transaction bill = db.Transactions.Find(id);

            int total = 0;
            foreach (var item in bill.Orders)
            {
                total += item.quantity.GetValueOrDefault();
            }

            return total;
        }

        public Transaction GetByID(int id)
        {
            return db.Transactions.Find(id);
        }
    }
}