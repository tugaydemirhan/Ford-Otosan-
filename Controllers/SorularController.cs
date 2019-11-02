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
    public class SorularController : Controller
    {
        private yenimvcEntities db = new yenimvcEntities();

        // GET: Sorular
        public ActionResult Index()
        {
            return View(db.Sorular.ToList());
        }

        // GET: Sorular/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorular sorular = db.Sorular.Find(id);
            if (sorular == null)
            {
                return HttpNotFound();
            }
            return View(sorular);
        }

        // GET: Sorular/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sorular/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Soruid,soru,cevap,cd_creater,cd_modifier,dt_created,dt_modified")] Sorular sorular)
        {
            if (ModelState.IsValid)
            {
                sorular.dt_created = DateTime.Now;
                sorular.cd_creater = (int)Session["userId"];

                db.Sorular.Add(sorular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sorular);
        }

        // GET: Sorular/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorular sorular = db.Sorular.Find(id);
            if (sorular == null)
            {
                return HttpNotFound();
            }
            return View(sorular);
        }

        // POST: Sorular/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Soruid,soru,cevap,cd_creater,cd_modifier,dt_created,dt_modified")] Sorular sorular)
        {
            if (ModelState.IsValid)
            {
                sorular.dt_modified = DateTime.Now;
                sorular.cd_modifier = (int)Session["userId"];
                db.Entry(sorular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sorular);
        }

        // GET: Sorular/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorular sorular = db.Sorular.Find(id);
            if (sorular == null)
            {
                return HttpNotFound();
            }
            return View(sorular);
        }

        // POST: Sorular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sorular sorular = db.Sorular.Find(id);
            db.Sorular.Remove(sorular);
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
