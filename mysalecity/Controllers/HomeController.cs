using mysalecity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mysalecity.Controllers
{ 
    public class HomeController : Controller
    {
        private mysale_dbEntities db = new mysale_dbEntities();

        // GET: categories
        public ActionResult Index()
        {

            var Categories = db.categories.ToList();
            this.ViewData["cat"] = Categories;

            return View();
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