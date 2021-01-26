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
using PryUserMonasterioS.Models;

namespace PryUserMonasterioS.Controllers
{
    public class RootsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Roots
        public IQueryable<Roots> GetRoots()
        {
            return db.Roots;
        }

        // GET: api/Roots/5
        [ResponseType(typeof(Roots))]
        public IHttpActionResult GetRoots(int id)
        {
            Roots roots = db.Roots.Find(id);
            if (roots == null)
            {
                return NotFound();
            }

            return Ok(roots);
        }

        // PUT: api/Roots/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoots(int id, Roots roots)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roots.id)
            {
                return BadRequest();
            }

            db.Entry(roots).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RootsExists(id))
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

        // POST: api/Roots
        [ResponseType(typeof(Roots))]
        public IHttpActionResult PostRoots(Roots roots)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roots.Add(roots);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roots.id }, roots);
        }

        // DELETE: api/Roots/5
        [ResponseType(typeof(Roots))]
        public IHttpActionResult DeleteRoots(int id)
        {
            Roots roots = db.Roots.Find(id);
            if (roots == null)
            {
                return NotFound();
            }

            db.Roots.Remove(roots);
            db.SaveChanges();

            return Ok(roots);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RootsExists(int id)
        {
            return db.Roots.Count(e => e.id == id) > 0;
        }
    }
}