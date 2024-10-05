using creativo_API.Models;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace creativo_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CantonsController : ApiController
    {
        private CreativoDBV2Entities db = new CreativoDBV2Entities();

        // GET: api/Cantons
        public List<Canton> GetCantons()
        {
            List<Canton> cantons = db.Cantons.ToList();
            foreach (var canton in db.Cantons)
            {
                canton.Districts = null;
            }
            return cantons;

        }

        // GET: api/Cantons/Provincia
        [HttpGet]
        [Route("api/Cantons/{province}")]
        public List<Canton> GetCantones(string province)
        {
            List<Canton> cantons = db.Cantons.Where(e => e.Province.Name == province).ToList();
            foreach (var canton in db.Cantons)
            {
                canton.Districts = null;
            }
            return cantons;

        }

        // GET: api/Cantons/5
        [ResponseType(typeof(Canton))]
        public IHttpActionResult GetCanton(string id)
        {
            Canton canton = db.Cantons.Find(id);
            if (canton == null)
            {
                return NotFound();
            }

            return Ok(canton);
        }

        // PUT: api/Cantons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCanton(string id, Canton canton)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != canton.Name)
            {
                return BadRequest();
            }

            db.Entry(canton).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CantonExists(id))
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

        // POST: api/Cantons
        [ResponseType(typeof(Canton))]
        public IHttpActionResult PostCanton(Canton canton)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cantons.Add(canton);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CantonExists(canton.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = canton.Name }, canton);
        }

        // DELETE: api/Cantons/5
        [ResponseType(typeof(Canton))]
        public IHttpActionResult DeleteCanton(string id)
        {
            Canton canton = db.Cantons.Find(id);
            if (canton == null)
            {
                return NotFound();
            }

            db.Cantons.Remove(canton);
            db.SaveChanges();

            return Ok(canton);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CantonExists(string id)
        {
            return db.Cantons.Count(e => e.Name == id) > 0;
        }
    }
}