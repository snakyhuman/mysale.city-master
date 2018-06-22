using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using mysalecity.Models;
using Newtonsoft.Json;
namespace mysalecity.Controllers
{
    public class tasks_viewController : ApiController
    {
        private mysale_dbEntities db = new mysale_dbEntities();

        // GET: api/tasks_view
        public IQueryable<tasks_view> Gettasks_view()
        {
            return db.tasks_view;
        }

        // GET: api/tasks_view/5
        [ResponseType(typeof(tasks_view))]
        public IHttpActionResult Gettasks_view(string id)
        {
            tasks_view tasks_view = db.tasks_view.SingleOrDefault(m => m.text == id); ;
            if (tasks_view == null)
            {
                return NotFound();
            }

            return Ok(tasks_view);
        }

        public JsonResult<IEnumerable<tasks_view>> GetPeopleDataJson(string selectedRole = "All")
        {
            IEnumerable<tasks_view> tasks = db.tasks_view.ToList<tasks_view>();
            var jsonResult = Json(tasks);
            return jsonResult;
        }

        // PUT: api/tasks_view/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttasks_view(string id, tasks_view tasks_view)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tasks_view.company_name)
            {
                return BadRequest();
            }

            db.Entry(tasks_view).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tasks_viewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tasks_view
        [ResponseType(typeof(tasks_view))]
        public IHttpActionResult Posttasks_view(tasks_view tasks_view)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tasks_view.Add(tasks_view);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tasks_viewExists(tasks_view.company_name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tasks_view.company_name }, tasks_view);
        }

        // DELETE: api/tasks_view/5
        [ResponseType(typeof(tasks_view))]
        public IHttpActionResult Deletetasks_view(string id)
        {
            tasks_view tasks_view = db.tasks_view.Find(id);
            if (tasks_view == null)
            {
                return NotFound();
            }

            db.tasks_view.Remove(tasks_view);
            db.SaveChanges();

            return Ok(tasks_view);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tasks_viewExists(string id)
        {
            return db.tasks_view.Count(e => e.company_name == id) > 0;
        }
    }
}