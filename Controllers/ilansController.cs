using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using baslangic1.Models;

namespace baslangic1.Controllers
{
    public class ilansController : Controller
    {
        private yenimvcEntities db = new yenimvcEntities();

        // GET: ilans
        public ActionResult Index()
        {
            return View(db.ilan.ToList());
        }

        // GET: ilans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ilan ilan = db.ilan.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // GET: ilans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ilans/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,baslik,baslangic,bitis,aciklama,pozisyon")] ilan ilan)
        {
            if (ModelState.IsValid)
            {
                db.ilan.Add(ilan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ilan);
        }

        // GET: ilans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ilan ilan = db.ilan.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // POST: ilans/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,baslik,baslangic,bitis,aciklama,pozisyon")] ilan ilan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ilan);
        }

        // GET: ilans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ilan ilan = db.ilan.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // POST: ilans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ilan ilan = db.ilan.Find(id);
            db.ilan.Remove(ilan);
            db.SaveChanges();
            return RedirectToAction("Index");
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
