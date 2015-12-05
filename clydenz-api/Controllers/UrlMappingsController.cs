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
    public class UrlMappingsController : ApiController
    {
        private clydenz_apiContext db = new clydenz_apiContext();

        // GET: api/UrlMappings
        public IQueryable<UrlMapping> GetUrlMappings()
        {
            return db.UrlMappings;
        }

        // GET: api/UrlMappings/5
        [ResponseType(typeof(UrlMapping))]
        public IHttpActionResult GetUrlMapping(int id)
        {
            UrlMapping urlMapping = db.UrlMappings.Find(id);
            if (urlMapping == null)
            {
                return NotFound();
            }

            return Ok(urlMapping);
        }

        // PUT: api/UrlMappings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUrlMapping(int id, UrlMapping urlMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != urlMapping.ID)
            {
                return BadRequest();
            }

            db.Entry(urlMapping).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrlMappingExists(id))
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

        // POST: api/UrlMappings
        [ResponseType(typeof(UrlMapping))]
        public IHttpActionResult PostUrlMapping(UrlMapping urlMapping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            
            db.UrlMappings.Add(urlMapping);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = urlMapping.ID }, urlMapping);
        }

        // DELETE: api/UrlMappings/5
        [ResponseType(typeof(UrlMapping))]
        public IHttpActionResult DeleteUrlMapping(int id)
        {
            UrlMapping urlMapping = db.UrlMappings.Find(id);
            if (urlMapping == null)
            {
                return NotFound();
            }

            db.UrlMappings.Remove(urlMapping);
            db.SaveChanges();

            return Ok(urlMapping);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UrlMappingExists(int id)
        {
            return db.UrlMappings.Count(e => e.ID == id) > 0;
        }
    }
}