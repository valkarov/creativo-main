﻿using System;
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
    public class WorkshopsController : ApiController
    {
        private CreativoDBV2Entities db = new CreativoDBV2Entities();
        // GET: api/Workshops
        public IQueryable<Workshop> GetWorkshops()
        {
            return db.Workshops;
        }

        // GET: api/Workshops/5
        [ResponseType(typeof(Workshop))]
        public IHttpActionResult GetWorkshop(int id)
        {
            Workshop workshop = db.Workshops.Find(id);
            if (workshop == null)
            {
                return NotFound();
            }

            return Ok(WorkshopRequestDto.workshopRequestDto(workshop));
        }

        // PUT: api/Workshops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorkshop(int id, WorkshopRequestDto workshopDto)
        {
            try
            {
                WorkshopRequestDto.MapToWorkshop(db, workshopDto);
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkshopExists(id))
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
        [HttpGet]
        [Route("api/Workshops/ByEntre/{id}")]
        public List<WorkshopRequestDto> GetWorkshopsByEntre(int id)
        {
            var workshops = db.Workshops.Where(w => w.EntrepeneurshipId == id).ToList();
            List<WorkshopRequestDto> workshopDtos = new List<WorkshopRequestDto>();
            foreach (var workshop in workshops)
            {
                workshopDtos.Add(WorkshopRequestDto.workshopRequestDto(workshop));
            }
            return workshopDtos;
        }
        // POST: api/Workshops
        [ResponseType(typeof(Workshop))]
        public IHttpActionResult PostWorkshop(WorkshopRequestDto workshopDto)
        {
            db.Workshops.Add(WorkshopRequestDto.MapToWorkshop(db, workshopDto));
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/Workshops/5
        [ResponseType(typeof(Workshop))]
        public IHttpActionResult DeleteWorkshop(int id)
        {
            Workshop workshop = db.Workshops.Find(id);
            if (workshop == null)
            {
                return NotFound();
            }

            db.Workshops.Remove(workshop);
            db.SaveChanges();

            return Ok(workshop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkshopExists(int id)
        {
            return db.Workshops.Count(e => e.Id == id) > 0;
        }
    }
}