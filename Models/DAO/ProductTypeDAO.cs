using Hoc_ASP.NET_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hoc_ASP.NET_MVC.Models.DAO
{
    public class ProductTypeDAO
    {
        private ShopContext db;
        public ProductTypeDAO()
        {
            db = new ShopContext();
        }

        public List<ProductType> GetList()
        {
            return db.ProductTypes.ToList();
        }

        public SelectList GetSelectLists()
        {
            var types = db.ProductTypes.ToList();
            var selectList = new SelectList(types, "ID", "Name");
            return selectList;
        }

        public SelectList GetSelectLists(int idFirstItem)
        {
            var types = db.ProductTypes.ToList();
            if (types.Count > 1)
            {
                for (int i = 0; i < types.Count; i++)
                {
                    if(types[i].id == idFirstItem)
                    {
                        ProductType temp = types[i];
                        types.RemoveAt(i);
                        types.Insert(0, temp);
                        break;
                    }
                }
            }

            var selectList = new SelectList(types, "ID", "Name");
            return selectList;
        }
    }
}