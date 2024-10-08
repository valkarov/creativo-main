using creativo_API.Models;
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
    public class DistricsController : ApiController
    {
        private CreativoDBV2Entities db = new CreativoDBV2Entities();

        // GET: api/Districs
        public IQueryable<District> GetDistrics()
        {
            return db.Districts;
        }
        // GET: api/Districs/Canton
        [HttpGet]
        [Route("api/Districs/{canton}")]
        public List<District> GetCantones(string canton)
        {
            List<District> districts= db.Districts.Where(e => e.Canton.Name == canton).ToList();
            foreach (var district in districts)
            {
                district.Users = null;
                district.Canton = null;
                district.Entrepeneurships = null;
                district.Orders = null;
            }
            return districts;
        }


        // GET: api/Districs/5
        [ResponseType(typeof(District))]
        public IHttpActionResult GetDistric(string id)
        {
            District distric = db.Districts.Where(d => d.Name == id).FirstOrDefault();
            if (distric == null)
            {
                return NotFound();
            }

            return Ok(distric);
        }

        // PUT: api/Districs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDistric(string id, District district)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != district.Name)
            {
                return BadRequest();
            }

            db.Entry(district).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistricExists(id))
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

        // POST: api/Districs
        [ResponseType(typeof(District))]
        public IHttpActionResult PostDistric(District district)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Districts.Add(district);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DistricExists(district.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = district.Name }, district);
        }

        // DELETE: api/Districs/5
        [ResponseType(typeof(District))]
        public IHttpActionResult DeleteDistric(string id)
        {
            District distric = db.Districts.Where(d => d.Name == id).FirstOrDefault();
            if (distric == null)
            {
                return NotFound();
            }

            db.Districts.Remove(distric);
            db.SaveChanges();

            return Ok(distric);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DistricExists(string id)
        {
            return db.Districts.Count(e => e.Name == id) > 0;
        }
    }
}