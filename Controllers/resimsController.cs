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
    public class resimsController : Controller
    {
        private yenimvcEntities db = new yenimvcEntities();

        // GET: resims
        public ActionResult Index()
        {
            return View(db.resim.ToList());
        }

        // GET: resims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resim resim = db.resim.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            return View(resim);
        }

        // GET: resims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: resims/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "resimId,isim,goruntuDosya")] resim resim)
        {
            if (ModelState.IsValid)
            {
                if (resim.goruntuDosya != null && resim.goruntuDosya.ContentLength > 0)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(resim.goruntuDosya.InputStream))
                    {
                        bytes = br.ReadBytes(resim.goruntuDosya.ContentLength);
                    }
                    resim.goruntu = bytes;
                }

                db.resim.Add(resim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resim);
        }

        // GET: resims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resim resim = db.resim.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            return View(resim);
        }

        // POST: resims/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "resimId,isim,goruntu")] resim resim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resim);
        }

        // GET: resims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resim resim = db.resim.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            return View(resim);
        }

        // POST: resims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resim resim = db.resim.Find(id);
            db.resim.Remove(resim);
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
