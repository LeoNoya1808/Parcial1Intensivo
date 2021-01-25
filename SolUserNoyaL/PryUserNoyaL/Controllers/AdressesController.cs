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
    public class AdressesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Adresses
        public IQueryable<Adress> GetAdresses()
        {
            return db.Adresses;
        }

        // GET: api/Adresses/5
        [ResponseType(typeof(Adress))]
        public IHttpActionResult GetAdress(string id)
        {
            Adress adress = db.Adresses.Find(id);
            if (adress == null)
            {
                return NotFound();
            }

            return Ok(adress);
        }

        // PUT: api/Adresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdress(string id, Adress adress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adress.street)
            {
                return BadRequest();
            }

            db.Entry(adress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdressExists(id))
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

        // POST: api/Adresses
        [ResponseType(typeof(Adress))]
        public IHttpActionResult PostAdress(Adress adress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Adresses.Add(adress);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdressExists(adress.street))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adress.street }, adress);
        }

        // DELETE: api/Adresses/5
        [ResponseType(typeof(Adress))]
        public IHttpActionResult DeleteAdress(string id)
        {
            Adress adress = db.Adresses.Find(id);
            if (adress == null)
            {
                return NotFound();
            }

            db.Adresses.Remove(adress);
            db.SaveChanges();

            return Ok(adress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdressExists(string id)
        {
            return db.Adresses.Count(e => e.street == id) > 0;
        }
    }
}