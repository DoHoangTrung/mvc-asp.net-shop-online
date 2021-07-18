using Hoc_ASP.NET_MVC.Models.Code;
using Hoc_ASP.NET_MVC.Models.DAO;
using Hoc_ASP.NET_MVC.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hoc_ASP.NET_MVC.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products

        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var sessionLogin = SessionLogin.Get();
            if (sessionLogin != null)
            {
                //load product type dropdownlist
                ProductTypeDAO typeDao = new ProductTypeDAO();
                var productTypes = typeDao.GetSelectLists();
                ViewBag.productTypes = productTypes;

                //load list products
                var products = Session["productsShowing"] as List<Product>;
                if (products == null)
                {
                    ProductDAO proDao = new ProductDAO();
                    products = proDao.GetList();
                }

                return View(products.ToPagedList(page, pageSize));
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpPost]
        public ActionResult Show(FormCollection form, int page = 1, int pageSize = 5)
        {
            ProductTypeDAO typeDao = new ProductTypeDAO();
            var productTypes = typeDao.GetSelectLists();
            ViewBag.productTypes = productTypes;

            //create search by multiple condition
            SearchModel searchModel = new SearchModel();

            //typeID condition
            bool check = int.TryParse(form["ddlType"], out int typeID);

            //Response.Write("<script>alert('"+check.ToString()+"');</script>");

            if (check)
            {
                searchModel.typeId = typeID;
            }

            //key words condition
            string keyWords = form["textSearch"].Trim();
            if (!string.IsNullOrEmpty(keyWords))
            {
                searchModel.keyWords = keyWords;
            }

            //prices condition
            string indexPrice = form["ddlPrice"];
            switch (indexPrice)
            {
                case "1":
                    searchModel.fromNumber = 0;
                    searchModel.toNumber = 500000;
                    break;
                case "2":
                    searchModel.fromNumber = 500000;
                    searchModel.toNumber = 1000000;
                    break;
                case "3":
                    searchModel.fromNumber = 1000000;
                    searchModel.toNumber = 1500000;
                    break;
                case "4":
                    searchModel.fromNumber = 1500000;
                    searchModel.toNumber = 200000;
                    break;
                case "5":
                    searchModel.fromNumber = 200000;
                    searchModel.toNumber = 200000000;
                    break;
                default:
                    break;
            }

            //search
            ProductDAO pDao = new ProductDAO();
            var searchResult = pDao.Search(searchModel);

            return View("~/Areas/Admin/Views/Products/Index.cshtml", searchResult.ToPagedList(page, pageSize));
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int id)
        {
            var sessionLogin = SessionLogin.Get();
            if (sessionLogin != null)
            {
                ProductDAO dao = new ProductDAO();
                Product product = dao.GetByID(id);
                if (product != null)
                {
                    return View(product);
                }
                else
                {
                    return View("../PageNotFound");
                }
            }
            else
            {
                return RedirectToAction("Login", "User",new { area = "" });
            }
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            var sessionLogin = SessionLogin.Get();
            if (sessionLogin != null)
            {
                ProductTypeDAO typeDAO = new ProductTypeDAO();
                var types = typeDAO.GetSelectLists();
                Session["types"] = types;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        // POST: Admin/Products/Create
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            try
            {
                ProductDAO dao = new ProductDAO();
                int id = dao.Insert(pro);

                return RedirectToAction("Index", "Products");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int id)
        {
            var sessionLogin = SessionLogin.Get();
            if (sessionLogin != null)
            {
                ProductTypeDAO typeDAO = new ProductTypeDAO();
                ProductDAO proDAO = new ProductDAO();

                Product product = proDAO.GetByID(id);
                if (product != null)
                {
                    Session["product"] = product;

                    var types = typeDAO.GetSelectLists(product.productTypeId.GetValueOrDefault());
                    Session["types"] = types;
                    return View();
                }
                else
                {
                    return View("../PageNotFound");
                }

            }
            else
            {
                return RedirectToAction("Login", "User", new { area = "" });
            }
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                ProductDAO dao = new ProductDAO();
                dao.Update(product);
                return RedirectToAction("Index", "Products");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int id)
        {
            var sessionLogin = SessionLogin.Get();
            if (sessionLogin != null)
            {
                ProductDAO dao = new ProductDAO();
                Product p = dao.GetByID(id);
                return View(p);
            }
            else
            {
                return RedirectToAction("Login", "User", new { area = "" });
            }
        }

        // POST: Admin/Products/Delete/5
        [HttpPost]
        public ActionResult Delete(Product pDel)
        {
            try
            {
                ProductDAO dao = new ProductDAO();
                dao.Delete(pDel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
