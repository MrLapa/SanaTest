using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SanaTest.Models;

namespace SanaTest.Controllers
{
    public class Sana_ProductCategorieController : Controller
    {
        private SanaEntities db = new SanaEntities();

        // GET: Sana_ProductCategorie
        public ActionResult Index()
        {
            return View(db.Sana_ProductCategorie.ToList());
        }

        // GET: Sana_ProductCategorie/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sana_ProductCategorie sana_ProductCategorie = db.Sana_ProductCategorie.Find(id);
            if (sana_ProductCategorie == null)
            {
                return HttpNotFound();
            }
            return View(sana_ProductCategorie);
        }

        // GET: Sana_ProductCategorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sana_ProductCategorie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProductCategorie,name,creationDate,modificationDate,enable")] Sana_ProductCategorie sana_ProductCategorie)
        {
            if (ModelState.IsValid)
            {
                db.Sana_ProductCategorie.Add(sana_ProductCategorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sana_ProductCategorie);
        }

        // GET: Sana_ProductCategorie/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sana_ProductCategorie sana_ProductCategorie = db.Sana_ProductCategorie.Find(id);
            if (sana_ProductCategorie == null)
            {
                return HttpNotFound();
            }
            return View(sana_ProductCategorie);
        }

        // POST: Sana_ProductCategorie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProductCategorie,name,creationDate,modificationDate,enable")] Sana_ProductCategorie sana_ProductCategorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sana_ProductCategorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sana_ProductCategorie);
        }

        // GET: Sana_ProductCategorie/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sana_ProductCategorie sana_ProductCategorie = db.Sana_ProductCategorie.Find(id);
            if (sana_ProductCategorie == null)
            {
                return HttpNotFound();
            }
            return View(sana_ProductCategorie);
        }

        // POST: Sana_ProductCategorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Sana_ProductCategorie sana_ProductCategorie = db.Sana_ProductCategorie.Find(id);
            db.Sana_ProductCategorie.Remove(sana_ProductCategorie);
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
