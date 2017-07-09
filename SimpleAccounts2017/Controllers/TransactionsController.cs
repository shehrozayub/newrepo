using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleAccounts2017.Controllers
{
    public class TransactionsController : Controller
    {
        simpleAccountsEntities db = new simpleAccountsEntities();
        // GET: Transactions
        public ActionResult CreateSale()
        {
            if (Session["UserID"] != null)
            {
                return View(db.sales.ToList());
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return RedirectToAction("Index", "Accounts");
            }

        }

        public ActionResult CreateNewSale(sale sale)
        {
            if (Session["UserID"] != null)
            {

                sale.createdOn = DateTime.Now;
                db.sales.Add(sale);
                db.SaveChanges();
                ViewBag.SucessMessage = "Sale Created Sucessfully!";
                return View("CreateSale");
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return RedirectToAction("Index", "Accounts");
            }
        }
        public ActionResult CreatePurchase()
        {
            if (Session["UserID"] != null)
            {
                return View(db.purchases.ToList());
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return RedirectToAction("Index", "Accounts");
            }
        }

        public ActionResult CreateNewPurchase(purchase purchase)
        {
            if (Session["UserID"] != null)
            {
                purchase.createdOn = DateTime.Now;
                db.purchases.Add(purchase);
                db.SaveChanges();
                ViewBag.SucessMessage = "Sale Created Sucessfully!";
                return View("CreateSale");
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return RedirectToAction("Index", "Accounts");
            }

        }

        public ActionResult EnterExpense()
        {
            if (Session["UserID"] != null)
            {
                return View(db.expenses.ToList());
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return RedirectToAction("Index", "Accounts");
            }


        }

        public ActionResult EnterNewExpense(expens exp)
        {
            if (Session["UserID"] != null)
            {
                exp.createdOn = DateTime.Now;
                db.expenses.Add(exp);
                db.SaveChanges();
                ViewBag.SucessMessage = "Expense entered Sucessfully!";
                return View("EnterExpense");
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return RedirectToAction("Index", "Accounts");
            }

        }

        public ActionResult CashReceipt()
        {
            if (Session["UserID"] != null)
            {
                return View(db.transactions.ToList());
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return RedirectToAction("Index", "Accounts");
            }


        }

        public ActionResult CashNewReceipt(transaction trans)
        {
            if (Session["UserID"] != null)
            {
                trans.createdOn = DateTime.Now;
                trans.transactiontype = false;
                db.transactions.Add(trans);
                db.SaveChanges();
                ViewBag.SucessMessage = "Cash Recieved Sucessfully!";
                return View("CashReceipt");
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return RedirectToAction("Index", "Accounts");
            }

        }

        public ActionResult CashPaid()
        {
            if (Session["UserID"] != null)
            {
                return View(db.transactions.ToList());
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return RedirectToAction("Index", "Accounts");
            }


        }

        public ActionResult CashNewPaid(transaction trans)
        {
            if (Session["UserID"] != null)
            {
                trans.createdOn = DateTime.Now;
                trans.transactiontype = true;
                db.transactions.Add(trans);
                db.SaveChanges();
                ViewBag.SucessMessage = "Cash Recieved Sucessfully!";
                return View("CashReceipt");
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return RedirectToAction("Index", "Accounts");
            }

        }


    }
}