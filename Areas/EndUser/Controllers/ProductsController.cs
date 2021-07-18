using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hoc_ASP.NET_MVC.Models.Code;
using Hoc_ASP.NET_MVC.Models.DAO;
using Hoc_ASP.NET_MVC.Models.Entity;

namespace Hoc_ASP.NET_MVC.Areas.EndUser.Controllers
{
    public class ProductsController : Controller
    {
        // GET: EndUser/Products
        public ActionResult Index()
        {
            ProductDAO dao = new ProductDAO();
            var products = dao.GetList();
            return View(products);
        }

        // GET: EndUser/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductDAO dao = new ProductDAO();
            Product product = dao.GetByID(id.GetValueOrDefault());
            if (product == null)
            {
                return View("../Shared/PageNotFound");
            }

            return View(product);
        }
    }
}
