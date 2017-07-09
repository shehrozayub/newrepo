using ClassLibrary1;
using SimpleAccounts2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleAccounts2017.Controllers
{
    public class AccountsController : Controller
    {
        simpleAccountsEntities db = new simpleAccountsEntities();

        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user user)
        {
            var query = (from userlist in db.users
                            where userlist.username == user.username && userlist.password == user.password
                            select new
                            {
                                userlist.userid,
                                userlist.username
                            }).ToList();
            if (query.FirstOrDefault() != null)
            {
                Session["UserName"] = query.FirstOrDefault().username;
                Session["UserID"] = query.FirstOrDefault().userid;

                return View("AccountsHome");
            }
            else
            {
                ViewBag.Msg = "Invalid Username or Password";
               return View("Index");
            }
        }

        public ActionResult AccountsHome()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return View("Index");
            }
        }

        public ActionResult CreateAccount()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return View("Index");
            }


        }

        public ActionResult CreateNewAccount(account acc)
        {
          
            if (Session["UserID"] != null)
            {
                acc.createdOn = DateTime.Now;
                db.accounts.Add(acc);
                db.SaveChanges();
                ViewBag.SucessMessage = "Account Created Sucessfully!";
                return View("CreateAccount");
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return View("Index");
            }

        }

        public JsonResult getName(String acc)
        {
            int id = int.Parse(acc);
            
            Object data = null;
            var query = (from accountlist in db.accounts
                         where accountlist.accountID == id
                         select new
                         {
                             accountlist.accountID,
                             accountlist.accountHead
                         }).ToList();
            String name = query.FirstOrDefault().accountHead;

            data = new
            {
                valid = true,
                nameToShow = name
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewAll()
        {
           
            if (Session["UserID"] != null)
            {
                List<account> accList = db.accounts.ToList();
                return View(accList);
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return View("Index");
            }

        }

        public ActionResult AccountDetails(int? id)
        {


            if (Session["UserID"] != null)
            {

                AccountDetailModel adm = new AccountDetailModel();

                adm.p = db.purchases.Where(item => item.accountID == id).ToList();

                adm.s = db.sales.Where(item => item.accountID == id).ToList();

                adm.cp = db.transactions.Where(item => item.accountid == id && item.transactiontype == true).ToList();

                adm.cr = db.transactions.Where(item => item.accountid == id && item.transactiontype == false).ToList();

                return View(adm);
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return View("Index");
            }

        }
            public ActionResult Logout()
            {
              Session.Abandon();
            return View("Index");
            }

        }

    }
