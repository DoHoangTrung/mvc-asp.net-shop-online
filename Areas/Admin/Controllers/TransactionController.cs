using Hoc_ASP.NET_MVC.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hoc_ASP.NET_MVC.Areas.Admin.Controllers
{
    public class TransactionController : Controller
    {
        public ActionResult ShowWaitBills()
        {
            TransactionDAO dao = new TransactionDAO();
            var bills = dao.GetWaitBills();
            return View("waitView", bills);
        }

        public ActionResult ShowTransportingBills()
        {
            TransactionDAO dao = new TransactionDAO();
            var bills = dao.GetTransportingBills();
            return View(bills);
        }
        public ActionResult ShowPaidBills()
        {
            TransactionDAO dao = new TransactionDAO();
            var bills = dao.GetPaidBills();
            return View(bills);
        }

        public ActionResult Print(int id)
        {
            TransactionDAO transactionDAO = new TransactionDAO();

            return View(transactionDAO.GetByID(id));
        }
    }
}