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
using clydenz_api.Models;

namespace clydenz_api.Controllers
{
    public class UrlHitsController : ApiController
    {
        private clydenz_apiContext db = new clydenz_apiContext();

        // GET: api/UrlHits
        public IQueryable<UrlHits> GetUrlHits()
        {
            return db.UrlHits;
        }

        // GET: api/UrlHits/5
        [ResponseType(typeof(UrlHits))]
        public IHttpActionResult GetUrlHits(int id)
        {
            UrlHits urlHits = db.UrlHits.Find(id);
            if (urlHits == null)
            {
                return NotFound();
            }

            return Ok(urlHits);
        }

        // PUT: api/UrlHits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUrlHits(int id, UrlHits urlHits)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != urlHits.ID)
            {
                return BadRequest();
            }

            db.Entry(urlHits).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrlHitsExists(id))
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

        // POST: api/UrlHits
        [ResponseType(typeof(UrlHits))]
        public IHttpActionResult PostUrlHits(UrlHits urlHits)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UrlHits.Add(urlHits);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = urlHits.ID }, urlHits);
        }

        // DELETE: api/UrlHits/5
        [ResponseType(typeof(UrlHits))]
        public IHttpActionResult DeleteUrlHits(int id)
        {
            UrlHits urlHits = db.UrlHits.Find(id);
            if (urlHits == null)
            {
                return NotFound();
            }

            db.UrlHits.Remove(urlHits);
            db.SaveChanges();

            return Ok(urlHits);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UrlHitsExists(int id)
        {
            return db.UrlHits.Count(e => e.ID == id) > 0;
        }
    }
}