using baslangic1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApplicationSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hakkinda()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "mail,parola")] User user)
        {
            System.Diagnostics.Debug.WriteLine("Debugging Login");

            if (ModelState.IsValid)
            {
                using (yenimvcEntities db = new yenimvcEntities())
                {
                    User obj = db.User.Where(a => a.mail.Equals(user.mail) && a.parola.Equals(user.parola)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["isAdmin"] = obj.isAdmin;
                        Session["UserID"] = obj.userId.ToString();
                        Session["userId"] = obj.userId;
                        Session["UserName"] = obj.mail.ToString();

                        if (obj.isAdmin == 0)
                        {
                            Session["Name"] = obj.isim.ToString() + " " + obj.soyisim.ToString();
                        }

                        return RedirectToAction("Index");
                    }

                    return View("LoginFail");
                }
            }
            else
            {
                return HttpNotFound();
            }

        }

        public ActionResult LoginFail()
        {
            return View();
        }

        public ActionResult NotAuthorized()
        {
            return View();
        }

    }
}