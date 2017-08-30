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
    public class Sana_ProductCategoryController : Controller
    {
        private SanaEntities db = new SanaEntities();

        // GET: Sana_ProductCategory
        public ActionResult Index()
        {
            return View(db.Sana_ProductCategory.ToList());
        }

        // GET: Sana_ProductCategory/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sana_ProductCategory sana_ProductCategory = db.Sana_ProductCategory.Find(id);
            if (sana_ProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(sana_ProductCategory);
        }

        // GET: Sana_ProductCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sana_ProductCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProductCategory,name,creationDate,modificationDate,enable")] Sana_ProductCategory sana_ProductCategory)
        {
            if (ModelState.IsValid)
            {
                sana_ProductCategory.creationDate = DateTime.Now;

                db.Sana_ProductCategory.Add(sana_ProductCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sana_ProductCategory);
        }

        // GET: Sana_ProductCategory/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sana_ProductCategory sana_ProductCategory = db.Sana_ProductCategory.Find(id);
            if (sana_ProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(sana_ProductCategory);
        }

        // POST: Sana_ProductCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProductCategory,name,creationDate,modificationDate,enable")] Sana_ProductCategory sana_ProductCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sana_ProductCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sana_ProductCategory);
        }

        // GET: Sana_ProductCategory/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sana_ProductCategory sana_ProductCategory = db.Sana_ProductCategory.Find(id);
            if (sana_ProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(sana_ProductCategory);
        }

        // POST: Sana_ProductCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Sana_ProductCategory sana_ProductCategory = db.Sana_ProductCategory.Find(id);
            db.Sana_ProductCategory.Remove(sana_ProductCategory);
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
