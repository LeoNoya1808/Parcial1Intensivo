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
using PryUserNoyaL.Models;

namespace PryUserNoyaL.Controllers
{
    public class RootsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Roots
        public IQueryable<Root> GetRoots()
        {
            return db.Roots;
        }

        // GET: api/Roots/5
        [ResponseType(typeof(Root))]
        public IHttpActionResult GetRoot(int id)
        {
            Root root = db.Roots.Find(id);
            if (root == null)
            {
                return NotFound();
            }

            return Ok(root);
        }

        // PUT: api/Roots/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoot(int id, Root root)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != root.id)
            {
                return BadRequest();
            }

            db.Entry(root).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RootExists(id))
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
        [ResponseType(typeof(Root))]
        public IHttpActionResult PostRoot(Root root)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roots.Add(root);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = root.id }, root);
        }

        // DELETE: api/Roots/5
        [ResponseType(typeof(Root))]
        public IHttpActionResult DeleteRoot(int id)
        {
            Root root = db.Roots.Find(id);
            if (root == null)
            {
                return NotFound();
            }

            db.Roots.Remove(root);
            db.SaveChanges();

            return Ok(root);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RootExists(int id)
        {
            return db.Roots.Count(e => e.id == id) > 0;
        }
    }
}