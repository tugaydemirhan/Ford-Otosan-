using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using baslangic1.Models;

namespace baslangic1.Controllers
{
    public class UsersController : Controller
    {
        private yenimvcEntities db = new yenimvcEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,parola,isim,soyisim,bölüm,öğretim_türü,telefon,mail,Not_Ortalamasi,cd_modifier,dt_modified,dt_created,isAdmin,applicationList,pictureFile")] User user)
        {
            if (ModelState.IsValid)
            {
                if (user.pictureFile != null && user.pictureFile.ContentLength > 0)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(user.pictureFile.InputStream))
                    {
                        bytes = br.ReadBytes(user.pictureFile.ContentLength);
                    }
                    user.picture = bytes;
                }

                user.dt_modified = DateTime.Now;
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Home");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,parola,isim,soyisim,bölüm,öğretim_türü,telefon,mail,Not_Ortalamasi,cd_modifier,dt_modified,dt_created,isAdmin,applicationList,pictureFile")] User user)
        {
            if (ModelState.IsValid)
            {
                if (user.pictureFile != null && user.pictureFile.ContentLength > 0)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(user.pictureFile.InputStream))
                    {
                        bytes = br.ReadBytes(user.pictureFile.ContentLength);
                    }
                    user.picture = bytes;
                }

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public FileResult Download(int? id)
        {
            User user = db.User.Find(id);
            return File(user.picture, ".pdf");
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
