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
using static creativo_API.Models.EntrepeneurshipAdminsModels;

namespace creativo_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EntrepeneurshipAdminsController : ApiController
    {
        private CreativoDBV2Entities db = new CreativoDBV2Entities();

        // GET: api/EntrepeneurshipAdmins
        public IQueryable<EntrepeneurshipAdmin> GetEntrepeneurshipAdmins()
        {
            return db.EntrepeneurshipAdmins;
        }
        [HttpGet]
        [Route("api/EntrepeneurshipAdmins/byEntre/{id}")]
        public IHttpActionResult GetEntrepeneurshipAdminsByEntre(int id)
        {
            var entrepeneurshipAdmins = db.EntrepeneurshipAdmins.Where(e => e.EntrepeneurshipId == id);
            List<EntrepeneurshipAdminDto> entrepeneurshipAdminDtos = new List<EntrepeneurshipAdminDto>();
            if (entrepeneurshipAdmins == null)
            {
                return NotFound();
            }
            foreach (var entrepeneurshipAdmin in entrepeneurshipAdmins)
            {
                entrepeneurshipAdminDtos.Add(new EntrepeneurshipAdminDto()
                {
                    IdEntrepreneurship = entrepeneurshipAdmin.Entrepeneurship.Id.ToString(),
                    IdClient = entrepeneurshipAdmin.User.UserName
                });
            }
            return Ok(entrepeneurshipAdminDtos);
        }
        // GET: api/EntrepeneurshipAdmins/5
        [ResponseType(typeof(EntrepeneurshipAdmin))]
        public IHttpActionResult GetEntrepeneurshipAdmin(int id)
        {
            EntrepeneurshipAdmin entrepeneurshipAdmin = db.EntrepeneurshipAdmins.Find(id);
            if (entrepeneurshipAdmin == null)
            {
                return NotFound();
            }

            return Ok(entrepeneurshipAdmin);
        }

        // POST: api/EntrepeneurshipAdmins
        [ResponseType(typeof(EntrepeneurshipAdmin))]
        public IHttpActionResult PostEntrepeneurshipAdmin(EntrepeneurshipAdminDto entrepeneurshipAdmin)
        {
            User user = db.Users.Where(u => u.UserName == entrepeneurshipAdmin.IdClient).FirstOrDefault();
            if(user== null)
            {
                return BadRequest();
            }
            Role entrepeneur = db.Roles.Where(r => r.Name == "EMPRENDIMIENTO").FirstOrDefault();
            db.EntrepeneurshipAdmins.Add(new EntrepeneurshipAdmin() { EntrepeneurshipId = int.Parse(entrepeneurshipAdmin.IdEntrepreneurship), UserId = user.Id});
            if (db.UserRoles.Where(ur => ur.UserId == user.Id && ur.RoleId == entrepeneur.Id).FirstOrDefault() == null)
            {
                db.UserRoles.Add(new UserRole()
                {
                    UserId = user.Id,
                    RoleId = entrepeneur.Id
                });
            }
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/EntrepeneurshipAdmins/5
        [ResponseType(typeof(EntrepeneurshipAdmin))]
        public IHttpActionResult DeleteEntrepeneurshipAdmin(int id)
        {
            EntrepeneurshipAdmin entrepeneurshipAdmin = db.EntrepeneurshipAdmins.Find(id);
            if (entrepeneurshipAdmin == null)
            {
                return NotFound();
            }

            db.EntrepeneurshipAdmins.Remove(entrepeneurshipAdmin);
            db.SaveChanges();

            return Ok(entrepeneurshipAdmin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntrepeneurshipAdminExists(int id)
        {
            return db.EntrepeneurshipAdmins.Count(e => e.Id == id) > 0;
        }
    }
}