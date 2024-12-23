﻿using creativo_API.Models;
using iText.Layout.Element;
using System.Collections.Generic;
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
    public class ProvincesController : ApiController
    {
        private CreativoDBV2Entities db = new CreativoDBV2Entities();

        // GET: api/Provinces
        public List<ProvinceDto> GetProvinces()
        {
            List<Province> provinces = db.Provinces.ToList();
            List<ProvinceDto> provincesDto = new List<ProvinceDto>();
            provinces.ForEach(p => provincesDto.Add(ProvinceDto.MapToProvinceDto(p)));
            return provincesDto;
        }

        // GET: api/Provinces/5
        [ResponseType(typeof(ProvinceDto))]
        public IHttpActionResult GetProvince(string id)
        {
            Province province = db.Provinces.Find(id);
            if (province == null)
            {
                return NotFound();
            }

            return Ok(ProvinceDto.MapToProvinceDto(province));
        }

        // PUT: api/Provinces/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProvince(string id, Province province)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != province.Name)
            {
                return BadRequest();
            }

            db.Entry(province).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinceExists(id))
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

        // POST: api/Provinces
        [ResponseType(typeof(Province))]
        public IHttpActionResult PostProvince(Province province)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Provinces.Add(province);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProvinceExists(province.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = province.Name }, province);
        }

        // DELETE: api/Provinces/5
        [ResponseType(typeof(Province))]
        public IHttpActionResult DeleteProvince(string id)
        {
            Province province = db.Provinces.Find(id);
            if (province == null)
            {
                return NotFound();
            }

            db.Provinces.Remove(province);
            db.SaveChanges();

            return Ok(province);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProvinceExists(string id)
        {
            return db.Provinces.Count(e => e.Name == id) > 0;
        }
    }
}