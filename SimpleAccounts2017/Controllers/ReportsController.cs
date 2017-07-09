using ClassLibrary1;
using SimpleAccounts2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleAccounts2017.Controllers
{
    public class ReportsController : Controller
    {
        simpleAccountsEntities db = new simpleAccountsEntities();

        // GET: Reports
        public ActionResult ProfitStatement()
        {
            if (Session["UserID"] != null)
            {
                AccountDetailModel adm = new AccountDetailModel();

                adm.p = db.purchases.ToList();

                adm.s = db.sales.ToList();

                adm.cp = db.transactions.Where(item => item.transactiontype == true).ToList();

                adm.cr = db.transactions.Where(item => item.transactiontype == false).ToList();

                adm.e = db.expenses.ToList();

                return View(adm);
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return RedirectToAction("Index", "Accounts");
            }
        }
    }
}