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
    public class companiesController : Controller
    {
        private mysale_dbEntities db = new mysale_dbEntities();

        // GET: companies
        public ActionResult Index()
        {
            var Categories = db.categories.ToList();
            this.ViewData["cat"] = Categories;
            var companies = db.companies.Include(c => c.category1).Include(c => c.city1).Include(c => c.company_status1);
            return View(companies.ToList());
        }

        // GET: companies/Details/5
        public ActionResult Details(long? id)
        {
            var Categories = db.categories.ToList();
            this.ViewData["cat"] = Categories;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company company = db.companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: companies/Create
        public ActionResult Create()
        {
            var Categories = db.categories.ToList();
            this.ViewData["cat"] = Categories;
            ViewBag.category = new SelectList(db.categories, "id", "name");
            ViewBag.city = new SelectList(db.cities, "id", "name");
            ViewBag.company_status = new SelectList(db.company_status, "id", "name");
            return View();
        }

        // POST: companies/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,company_name,city,adress,web_adress,company_login,company_password,inn,personal_account,registration_date,paying_time,company_status,category")] company company)
        {
            var Categories = db.categories.ToList();
            this.ViewData["cat"] = Categories;
            if (ModelState.IsValid)
            {
                db.companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category = new SelectList(db.categories, "id", "name", company.category);
            ViewBag.city = new SelectList(db.cities, "id", "name", company.city);
            ViewBag.company_status = new SelectList(db.company_status, "id", "name", company.company_status);
            return View(company);
        }

        // GET: companies/Edit/5
        public ActionResult Edit(long? id)
        {
            var Categories = db.categories.ToList();
            this.ViewData["cat"] = Categories;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company company = db.companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.category = new SelectList(db.categories, "id", "name", company.category);
            ViewBag.city = new SelectList(db.cities, "id", "name", company.city);
            ViewBag.company_status = new SelectList(db.company_status, "id", "name", company.company_status);
            return View(company);
        }

        // POST: companies/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,company_name,city,adress,web_adress,company_login,company_password,inn,personal_account,registration_date,paying_time,company_status,category")] company company)
        {
            var Categories = db.categories.ToList();
            this.ViewData["cat"] = Categories;
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category = new SelectList(db.categories, "id", "name", company.category);
            ViewBag.city = new SelectList(db.cities, "id", "name", company.city);
            ViewBag.company_status = new SelectList(db.company_status, "id", "name", company.company_status);
            return View(company);
        }

        // GET: companies/Delete/5
        public ActionResult Delete(long? id)
        {
            var Categories = db.categories.ToList();
            this.ViewData["cat"] = Categories;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company company = db.companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var Categories = db.categories.ToList();
            this.ViewData["cat"] = Categories;
            company company = db.companies.Find(id);
            db.companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            var Categories = db.categories.ToList();
            this.ViewData["cat"] = Categories;
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
