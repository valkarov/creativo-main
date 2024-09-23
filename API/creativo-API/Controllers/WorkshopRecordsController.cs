using creativo_API.Models;
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
    public class WorkshopRecordsController : ApiController
    {
        private creativoDBEntity db = new creativoDBEntity();

        // GET: api/WorkshopRecords
        public IQueryable<WorkshopRecord> GetWorkshopRecords()
        {
            return db.WorkshopRecords;
        }

        // GET: api/WorkshopRecords/5
        [ResponseType(typeof(WorkshopRecord))]
        public IHttpActionResult GetWorkshopRecord(int id)
        {
            WorkshopRecord workshopRecord = db.WorkshopRecords.Find(id);
            if (workshopRecord == null)
            {
                return NotFound();
            }

            return Ok(workshopRecord);
        }

        // GET: api/Workshops/byEntre/{entre_user}
        [HttpGet]
        [Route("api/WorkshopRecords/byEntre/{entre_user}")]
        public IQueryable<WorkshopRecord> GetWorkshop_by_entre(string entre_user)
        {

            // Obtén la lista de talleres que coinciden con el entre_user
            var workshops = db.Workshops
                .Where(w => w.IdEntrepreneurship == entre_user)
                .ToList(); // O ToListAsync() si estás usando Entity Framework

            // Obtén los Ids de los talleres filtrados
            var workshopIds = workshops.Select(w => w.IdWorkshop).ToList();

            // Filtra los registros de talleres para obtener solo aquellos cuyo IdWorkshop esté en la lista filtrada
            var workshopRecords = db.WorkshopRecords
                .Where(wr => workshopIds.Contains((int)wr.IdWorkshop));

            return workshopRecords;
        }



        // PUT: api/WorkshopRecords/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorkshopRecord(int id, WorkshopRecord workshopRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workshopRecord.Id)
            {
                return BadRequest();
            }



            db.Entry(workshopRecord).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkshopRecordExists(id))
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

        // POST: api/WorkshopRecords
        [ResponseType(typeof(WorkshopRecord))]
        public IHttpActionResult PostWorkshopRecord(WorkshopRecord workshopRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WorkshopRecords.Add(workshopRecord);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = workshopRecord.Id }, workshopRecord);
        }

        // DELETE: api/WorkshopRecords/5
        [ResponseType(typeof(WorkshopRecord))]
        public IHttpActionResult DeleteWorkshopRecord(int id)
        {
            WorkshopRecord workshopRecord = db.WorkshopRecords.Find(id);
            if (workshopRecord == null)
            {
                return NotFound();
            }

            db.WorkshopRecords.Remove(workshopRecord);
            db.SaveChanges();

            return Ok(workshopRecord);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkshopRecordExists(int id)
        {
            return db.WorkshopRecords.Count(e => e.Id == id) > 0;
        }
    }
}