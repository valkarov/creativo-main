using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using creativo_API.Models;

namespace creativo_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EntrepeneurshipTypesController : ApiController
    {
        private CreativoDBV2Entities db = new CreativoDBV2Entities();

        // GET: api/EntrepeneurshipTypes
        [HttpGet]
        [Route("api/Entrepreneurship_Type")]
        public IQueryable<EntrepeneurshipType> GetEntrepeneurshipTypes()
        {
            return db.EntrepeneurshipTypes;
        }

        // GET: api/EntrepeneurshipTypes/5
        [ResponseType(typeof(EntrepeneurshipType))]
        public IHttpActionResult GetEntrepeneurshipType(int id)
        {
            EntrepeneurshipType entrepeneurshipType = db.EntrepeneurshipTypes.Find(id);
            if (entrepeneurshipType == null)
            {
                return NotFound();
            }

            return Ok(entrepeneurshipType);
        }

        // PUT: api/EntrepeneurshipTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrepeneurshipType(int id, EntrepeneurshipType entrepeneurshipType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entrepeneurshipType.Id)
            {
                return BadRequest();
            }

            db.Entry(entrepeneurshipType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntrepeneurshipTypeExists(id))
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

        // POST: api/EntrepeneurshipTypes
        [ResponseType(typeof(EntrepeneurshipType))]
        public IHttpActionResult PostEntrepeneurshipType(EntrepeneurshipType entrepeneurshipType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EntrepeneurshipTypes.Add(entrepeneurshipType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = entrepeneurshipType.Id }, entrepeneurshipType);
        }

        // DELETE: api/EntrepeneurshipTypes/5
        [ResponseType(typeof(EntrepeneurshipType))]
        public IHttpActionResult DeleteEntrepeneurshipType(int id)
        {
            EntrepeneurshipType entrepeneurshipType = db.EntrepeneurshipTypes.Find(id);
            if (entrepeneurshipType == null)
            {
                return NotFound();
            }

            db.EntrepeneurshipTypes.Remove(entrepeneurshipType);
            db.SaveChanges();

            return Ok(entrepeneurshipType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntrepeneurshipTypeExists(int id)
        {
            return db.EntrepeneurshipTypes.Count(e => e.Id == id) > 0;
        }
    }
}