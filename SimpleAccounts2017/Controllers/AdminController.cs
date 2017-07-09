using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleAccounts2017.Controllers
{
    public class AdminController : Controller
    {
        simpleAccountsEntities db = new simpleAccountsEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(admin user)
        {
            var query = (from userlist in db.admins
                         where userlist.username == user.username && userlist.password == user.password
                         select new
                         {
                             userlist.adminid,
                             userlist.username
                         }).ToList();
            if (query.FirstOrDefault() != null)
            {
                Session["UserName"] = query.FirstOrDefault().username;
                Session["AdminID"] = query.FirstOrDefault().adminid;

                return View("Dashboard");
            }
            else
            {
                ViewBag.Msg = "Invalid Username or Password";
                return View("Index");
            }
        }
        public ActionResult Dashboard()
        {

            if (Session["AdminID"] != null)
            {
                return View();
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return View("Index");
            }
        }

        public ActionResult CreateUser()
        {
            if (Session["AdminID"] != null)
            {
                return View();
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return View("Index");
            }

        }

        public ActionResult CreateNewUser(user u)
        {
            if (Session["AdminID"] != null)
            {
                db.users.Add(u);
                db.SaveChanges();
                ViewBag.SucessMessage = "User Created Sucessfully!";
                return View("CreateUser");
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return View("Index");
            }

        }

        public ActionResult ViewAll()
        {
            if (Session["AdminID"] != null)
            {
                List<user> uList = db.users.ToList();
                return View(uList);
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return View("Index");
            }

        }

        public ActionResult DeleteUser(int? id)
        {
            if (Session["AdminID"] != null)
            {
                user u = db.users.Find(id);
                //Delete it from memory
                db.users.Remove(u);
                //Save to database
                db.SaveChanges();

                ViewBag.SucessMessage = "User Deleted Sucessfully!";

                return View("Dashboard");
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return View("Index");
            }

        }


        public ActionResult ViewPurchases()
        {
            if (Session["AdminID"] != null)
            {
                List<purchase> uList = db.purchases.ToList();
                return View(uList);
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return View("Index");
            }

        }

        public ActionResult ViewSales()
        {
            if (Session["AdminID"] != null)
            {
                List<sale> uList = db.sales.ToList();
                return View(uList);
            }

            else
            {
                ViewBag.Msg = "No Session Found";
                return View("Index");
            }

        }

        public ActionResult ViewExpenses()
        {
            if (Session["AdminID"] != null)
            {
                List<expens> uList = db.expenses.ToList();
                return View(uList);
            }
            else
            {
                ViewBag.Msg = "No Session Found";
                return View("Index");
            }

        }







    }
}