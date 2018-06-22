using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mysalecity.Models;

namespace mysalecity.Controllers
{
    public class company_statusController : Controller
    {
        private mysale_dbEntities db = new mysale_dbEntities();

        // GET: company_status
        public ActionResult Index()
        {
            return View(db.company_status.ToList());
        }

        // GET: company_status/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company_status company_status = db.company_status.Find(id);
            if (company_status == null)
            {
                return HttpNotFound();
            }
            return View(company_status);
        }

        // GET: company_status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: company_status/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] company_status company_status)
        {
            if (ModelState.IsValid)
            {
                db.company_status.Add(company_status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company_status);
        }

        // GET: company_status/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company_status company_status = db.company_status.Find(id);
            if (company_status == null)
            {
                return HttpNotFound();
            }
            return View(company_status);
        }

        // POST: company_status/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] company_status company_status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company_status);
        }

        // GET: company_status/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company_status company_status = db.company_status.Find(id);
            if (company_status == null)
            {
                return HttpNotFound();
            }
            return View(company_status);
        }

        // POST: company_status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            company_status company_status = db.company_status.Find(id);
            db.company_status.Remove(company_status);
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
