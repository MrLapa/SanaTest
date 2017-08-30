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
    public class Sana_ProductController : Controller
    {
        private SanaEntities db = new SanaEntities();

        // GET: Sana_Product
        public ActionResult Index()
        {
            return View(db.Sana_Product.ToList());
        }

        // GET: Sana_Product/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sana_Product sana_Product = db.Sana_Product.Find(id);
            if (sana_Product == null)
            {
                return HttpNotFound();
            }
            return View(sana_Product);
        }

        // GET: Sana_Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sana_Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProduct,title,price,productNumber,creationDate,modificationDate,enable")] Sana_Product sana_Product)
        {
            if (ModelState.IsValid)
            {                
                sana_Product.creationDate = DateTime.Now;
                
                db.Sana_Product.Add(sana_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sana_Product);
        }

        // GET: Sana_Product/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sana_Product sana_Product = db.Sana_Product.Find(id);
            if (sana_Product == null)
            {
                return HttpNotFound();
            }
            return View(sana_Product);
        }

        // POST: Sana_Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProduct,title,price,productNumber,creationDate,modificationDate,enable")] Sana_Product sana_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sana_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sana_Product);
        }

        // GET: Sana_Product/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sana_Product sana_Product = db.Sana_Product.Find(id);
            if (sana_Product == null)
            {
                return HttpNotFound();
            }
            return View(sana_Product);
        }

        // POST: Sana_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Sana_Product sana_Product = db.Sana_Product.Find(id);
            db.Sana_Product.Remove(sana_Product);
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

        public JsonResult CheckProductNumber(long productNumber)
        {
            var result = true;

            if (db.Sana_Product.Any(m => m.productNumber == productNumber))
            {
                result = false;
            }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
