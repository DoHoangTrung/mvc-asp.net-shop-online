using Hoc_ASP.NET_MVC.Models.Code;
using Hoc_ASP.NET_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Hoc_ASP.NET_MVC.Models.DAO
{
    public class ProductDAO
    {
        private ShopContext db;
        public ProductDAO()
        {
            db = new ShopContext();
        }
        public List<Product> GetProducts()
        {
            var products = db.Products.ToList();
            return products;
        }

        public List<Product> GetProductsByType(int idType)
        {
            var products = (from p in db.Products
                            where p.productTypeId == idType
                            select p).ToList();
            return products;
        }

        public List<Product> GetProductsByType(List<Product> products,int idType)
        {
            var result = products.Where((p) =>
            {
                return p.productTypeId == idType;
            }).Select(p => p).ToList();
            return result;
        }

        public int Insert(Product p)
        {
            if (p != null)
            {
                db.Products.Add(p);
                db.SaveChanges();
                return p.id;
            }
            else return -1;
        }

        public Product GetProductByID(int id)
        {
            return db.Products.Find(id);
        }

        public void Update(Product pUpdate)
        {
            if (pUpdate != null)
            {
                Product p = db.Products.Find(pUpdate.id);
                p.name = pUpdate.name;
                p.quantity = pUpdate.quantity;
                p.price = pUpdate.price;
                p.productTypeId = pUpdate.productTypeId;
                if (pUpdate.img0 != null)
                {
                    p.img0 = pUpdate.img0;
                }

                if (pUpdate.img1 != null)
                {
                    p.img1 = pUpdate.img1;
                }
                if (pUpdate.img2 != null)
                {
                    p.img2 = pUpdate.img2;
                }
                p.supplier = pUpdate.supplier;
                db.SaveChanges();
            }
        }

        public void Delete(Product pDel)
        {
            if (pDel != null)
            {
                Product p = db.Products.Find(pDel.id);
                db.Products.Remove(p);
                db.SaveChanges();
            }
        }

        string Format(string text)
        {
            // trim;
            text = text.Trim();
            //remove duplicate space in text
            text = Regex.Replace(text, @"\s\s+"," ");

            text = text.ToLower();

            // remove accent
            StringBuilder result = new StringBuilder();
            var arrayText = text.ToLower().Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char c in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    result.Append(c);
                }
            }

            return result.ToString().Normalize(NormalizationForm.FormC);
        }
        public List<Product> Search(string textSearch)
        {
            var products = db.Products.ToList();

            products = products.Where((p) =>
            {
                string s, keyWords;
                s = p.name + " " + p.ProductType.name + " " + p.supplier;
                keyWords = textSearch;

                s = Format(s);
                keyWords = Format(keyWords);

                if (s.Contains(keyWords))
                    return true;
                else
                    return false;
            }).Select(p => p).ToList();

            return products;
        }

        public List<Product> Search(SearchModel searchModel)
        {
            List<Product> products = db.Products.ToList();
            if (!string.IsNullOrEmpty(searchModel.keyWords))
            {
                products = products.Where((p) =>
                {
                    string keyWords = searchModel.keyWords.Format();
                    string str = (p.name + p.ProductType.name).Format();
                    return str.Contains(keyWords);
                }).Select(p=>p).ToList();
            }

            int? fromNumber, toNumber;
            fromNumber = searchModel.fromNumber;
            toNumber = searchModel.toNumber;
            if (toNumber != null && fromNumber!= null)
            {
                products = products.Where((p) =>
                {
                    if (fromNumber < p.price && p.price <= toNumber)
                        return true;
                    else
                        return false;
                }).Select(p => p).ToList();
            }

            int? typeID = searchModel.typeId;
            if(typeID!= null)
            {
                products = products.Where(p => p.productTypeId == typeID).Select(p => p).ToList();
            }

            return products.OrderBy(p => p.name).ToList();
        }
    }
}