using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using creativo_API.Models;
using creativo_API.Services;
using static creativo_API.Models.EntrepeneurshipDto;

namespace creativo_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EntrepeneurshipsController : ApiController
    {
        enum State { Pendiente = 1, Aceptada = 2, Rechazada = 3}; 
        private CreativoDBV2Entities db = new CreativoDBV2Entities();
        private SessionService sessionService = SessionService.Instance;
        // GET: api/Entrepeneurships
        public List<EntrepeneurshipRequestDto> GetEntrepeneurships()
        {
            List<Entrepeneurship> entrepeneurships = db.Entrepeneurships.ToList();
            List<EntrepeneurshipRequestDto> entrepeneurshipDtos = new List<EntrepeneurshipRequestDto>();
            foreach (var item in entrepeneurships)
            {
                entrepeneurshipDtos.Add(EntrepeneurshipRequestDto.MapFromEntrepeneurhip(item));
            }


            return entrepeneurshipDtos;
        }

        [HttpGet]
        [Route("api/Entrepeneurships/byClient")]
        public IHttpActionResult GetEntrepeneurshipByUser()
        {
            List<EntrepeneurshipRequestDto> entrepeneurshipDtos = new List<EntrepeneurshipRequestDto>();
            string authorization = Request.Headers.GetValues("Authorization").FirstOrDefault();
            string[] strings = authorization.Split(' ');
            int userId = sessionService.GetSession(strings[1]);
            User user = db.Users.Find(userId);
            if (user == null)
            {
                return Unauthorized();
            }
            List<Entrepeneurship> entrepeneurships = db.Entrepeneurships.Where(e => e.EntrepeneurshipAdmins.Any(ea => ea.UserId == user.Id)).ToList();
            foreach(var entrepeneurship in entrepeneurships)
            {
                List<EntrepeneurshipSocialRequest> entrepeneurshipSocialRequests = new List<EntrepeneurshipSocialRequest>();
                foreach(var entrepeneurshipSocial in entrepeneurship.EntrepeneurshipSocials)
                {
                    entrepeneurshipSocialRequests.Add(new EntrepeneurshipSocialRequest()
                    {
                        Id = entrepeneurshipSocial.SocialId,
                        Type = entrepeneurshipSocial.Social.SocialType.Name,
                        Link = entrepeneurshipSocial.Social.UserName,
                    });
                }
                entrepeneurshipDtos.Add(new EntrepeneurshipRequestDto()
                {
                    IdType = entrepeneurship.Reason,
                    Name = entrepeneurship.Name,
                    IdEntrepreneurship = entrepeneurship.Id,
                    Type = entrepeneurship.EntrepeneurshipType.Name,
                    Email = entrepeneurship.Email,
                    Sinpe = entrepeneurship.Sinpe,
                    Phone = entrepeneurship.Phone,
                    Description = entrepeneurship.Description,
                    District = entrepeneurship.District.Name,
                    Province = entrepeneurship.District.Canton.Province.Name,
                    Canton = entrepeneurship.District.Canton.Name,
                    State = entrepeneurship.state == 1 ? "Pendiente" : entrepeneurship.state == 2 ? "Aceptada" : "Rechazada",
                    Socials = entrepeneurshipSocialRequests.ToArray()

                });
            }
            return Ok(entrepeneurshipDtos);
        }
        [HttpGet]
        [Route("api/Entrepeneurships/Solicitudes")]
        public IHttpActionResult getSolicitudes()
        {
            List<EntrepeneurshipRequestDto> entrepeneurshipDtos = new List<EntrepeneurshipRequestDto>();
            string authorization = Request.Headers.GetValues("Authorization").FirstOrDefault();
            string[] strings = authorization.Split(' ');
            int userId = sessionService.GetSession(strings[1]);
            User user = db.Users.Find(userId);
            if (user == null || user.UserRoles.Any(ur => ur.Role.Name == "ADMIN") == false)
            {
                return Unauthorized();
            }
            List<Entrepeneurship> entrepeneurships = db.Entrepeneurships.Where(e => e.state == 1).ToList();
            foreach (var entrepeneurship in entrepeneurships)
            {
                List<EntrepeneurshipSocialRequest> entrepeneurshipSocialRequests = new List<EntrepeneurshipSocialRequest>();
                foreach (var entrepeneurshipSocial in entrepeneurship.EntrepeneurshipSocials)
                {
                    entrepeneurshipSocialRequests.Add(new EntrepeneurshipSocialRequest()
                    {
                        Id = entrepeneurshipSocial.SocialId,
                        Type = entrepeneurshipSocial.Social.SocialType.Name,
                        Link = entrepeneurshipSocial.Social.UserName,
                    });
                }
                entrepeneurshipDtos.Add(new EntrepeneurshipRequestDto()
                {
                    IdType = entrepeneurship.Reason,
                    Name = entrepeneurship.Name,
                    IdEntrepreneurship = entrepeneurship.Id,
                    Type = entrepeneurship.EntrepeneurshipType.Name,
                    Email = entrepeneurship.Email,
                    Sinpe = entrepeneurship.Sinpe,
                    Phone = entrepeneurship.Phone,
                    Description = entrepeneurship.Description,
                    District = entrepeneurship.District.Name,
                    Province = entrepeneurship.District.Canton.Province.Name,
                    Canton = entrepeneurship.District.Canton.Name,
                    State = entrepeneurship.state == 1 ?  "Pendiente": entrepeneurship.state == 2 ? "Aceptada" :"Rechazada",
                    Socials = entrepeneurshipSocialRequests.ToArray()

                });
            }
            return Ok(entrepeneurshipDtos);
        }
        // GET: api/Entrepeneurships/5
        [ResponseType(typeof(Entrepeneurship))]
        public IHttpActionResult GetEntrepeneurship(int id)
        {
            Entrepeneurship entrepeneurship = db.Entrepeneurships.Find(id);
            List<EntrepeneurshipSocialRequest> entrepeneurshipSocialRequests = new List<EntrepeneurshipSocialRequest>();
            foreach (var entrepeneurshipSocial in entrepeneurship.EntrepeneurshipSocials)
            {
                entrepeneurshipSocialRequests.Add(new EntrepeneurshipSocialRequest()
                {
                    Id = entrepeneurshipSocial.SocialId,
                    Type = entrepeneurshipSocial.Social.SocialType.Name,
                    Link = entrepeneurshipSocial.Social.UserName,
                });
            }
            EntrepeneurshipRequestDto entrepeneurshipDtos = new EntrepeneurshipRequestDto()
            {
                IdType = entrepeneurship.Reason,
                Name = entrepeneurship.Name,
                IdEntrepreneurship = entrepeneurship.Id,
                Type = entrepeneurship.EntrepeneurshipType.Name,
                Email = entrepeneurship.Email,
                Sinpe = entrepeneurship.Sinpe,
                Phone = entrepeneurship.Phone,
                Description = entrepeneurship.Description,
                District = entrepeneurship.District.Name,
                Province = entrepeneurship.District.Canton.Province.Name,
                Canton = entrepeneurship.District.Canton.Name,
                State = entrepeneurship.state == 1 ? "Pendiente" : entrepeneurship.state == 2 ? "Aceptada" : "Rechazada",
                Socials = entrepeneurshipSocialRequests.ToArray()
            };

            return Ok(entrepeneurshipDtos);
        }

        // PUT: api/Entrepeneurships/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrepeneurship(int id, EntrepeneurshipRequestDto entrepeneurshipDto)
        {
            string authorization = Request.Headers.GetValues("Authorization").FirstOrDefault();
            string[] strings = authorization.Split(' ');
            int userId = sessionService.GetSession(strings[1]);
            User user = db.Users.Find(userId);
            if (user == null)
            {
                return Unauthorized();
            }

            Entrepeneurship entrepeneurship = db.Entrepeneurships.Where(e => e.Id == id).FirstOrDefault();
            if(entrepeneurship == null)
            {
                return NotFound();
            }
            entrepeneurship.Reason = entrepeneurshipDto.IdType;
            int EntrepeneurshipTypeId = 0;
            try
            {
                EntrepeneurshipTypeId = int.Parse(entrepeneurshipDto.Type);
            }
            catch
            {
                EntrepeneurshipTypeId = db.EntrepeneurshipTypes.Where(et => et.Name == entrepeneurshipDto.Type).FirstOrDefault().Id;
            }
            entrepeneurship.EntrepeneurshipType = db.EntrepeneurshipTypes.Find(EntrepeneurshipTypeId);
            entrepeneurship.Name = entrepeneurshipDto.Name;
            entrepeneurship.Email = entrepeneurshipDto.Email;
            entrepeneurship.Sinpe = entrepeneurshipDto.Sinpe;
            entrepeneurship.Phone = entrepeneurshipDto.Phone;
            entrepeneurship.Description = entrepeneurshipDto.Description;
            entrepeneurship.Address = "";
            District district = db.Districts.Where(d => d.Name == entrepeneurshipDto.District).FirstOrDefault();

            if (district == null)
            {
                return BadRequest();
            }

            entrepeneurship.DistrictId = district.Id;

            if (entrepeneurshipDto.State == "Pendiente")
            {
                entrepeneurship.state = 1;
            }
            else if (entrepeneurshipDto.State == "Aceptada")
            {
                entrepeneurship.state = 2;
            }
            else if (entrepeneurshipDto.State == "Rechazada")
            {
                entrepeneurship.state = 3;
            }
            List<Social> socials = new List<Social>();
            foreach (var socialDto in entrepeneurshipDto.Socials)
            {
                SocialType socialType = db.SocialTypes.Where(st => st.Name == socialDto.Type).FirstOrDefault();
                if (socialType == null)
                {
                    return BadRequest();
                }
                Social social = entrepeneurship.EntrepeneurshipSocials.Select(es => es.Social).Where(s => s.Id == socialDto.Id).FirstOrDefault();
                if (social == null)
                {
                    social = new Social();
                }
                social.SocialTypeId = socialType.Id;
                social.UserName = socialDto.Link;

                socials.Add(social);
            }

            foreach (var social in socials)
            {
                db.Socials.AddOrUpdate(social);
                if (social.EntrepeneurshipSocials.Count == 0)
                {
                    db.EntrepeneurshipSocials.AddOrUpdate(new Models.EntrepeneurshipSocial()
                    {
                        EntrepeneurshipId = entrepeneurship.Id,
                        SocialId = social.Id
                    });
                }
            }
            db.Entrepeneurships.AddOrUpdate(entrepeneurship);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Entrepeneurships
        [HttpPost]
        [ResponseType(typeof(Entrepeneurship))]
        public IHttpActionResult PostEntrepeneurship(EntrepeneurshipRequestDto entrepeneurshipDto)
        {
            string authorization = Request.Headers.GetValues("Authorization").FirstOrDefault();
            string[] strings = authorization.Split(' ');
            int userId = sessionService.GetSession(strings[1]);
            User user = db.Users.Find(userId);
            if (user == null)
            {
                return Unauthorized();
            }
            Role entrepeneur = db.Roles.Where(r => r.Name == "EMPRENDIMIENTO").FirstOrDefault();
            Entrepeneurship entrepeneurship = new Entrepeneurship();
            entrepeneurship.Reason = entrepeneurshipDto.IdType;
            entrepeneurship.EntrepeneurshipType = db.EntrepeneurshipTypes.Find(int.Parse(entrepeneurshipDto.Type));
            entrepeneurship.Name = entrepeneurshipDto.Name;
            entrepeneurship.Email = entrepeneurshipDto.Email;
            entrepeneurship.Sinpe = entrepeneurshipDto.Sinpe;
            entrepeneurship.Phone = entrepeneurshipDto.Phone;
            entrepeneurship.Description = entrepeneurshipDto.Description;
            entrepeneurship.Address = "";
            District district = db.Districts.Where(d => d.Name == entrepeneurshipDto.District).FirstOrDefault();

            if (district == null)
            {
                return BadRequest();
            }

            entrepeneurship.DistrictId = district.Id;
            entrepeneurship.state = 1;
            if(db.UserRoles.Where(ur => ur.UserId == user.Id && ur.RoleId == entrepeneur.Id).FirstOrDefault() == null)
            {
                db.UserRoles.Add(new UserRole()
                {
                    UserId = user.Id,
                    RoleId = entrepeneur.Id
                });
            }
            db.Entrepeneurships.Add(entrepeneurship);
            db.EntrepeneurshipAdmins.Add(new EntrepeneurshipAdmin()
            {
                EntrepeneurshipId = entrepeneurship.Id,
                UserId = user.Id
            });
            List<Social> socials = new List<Social>();
            foreach (var socialDto in entrepeneurshipDto.Socials)
            {
                SocialType socialType = db.SocialTypes.Where(st => st.Name == socialDto.Type).FirstOrDefault();
                if (socialType == null)
                {
                    return BadRequest();
                }
                Social social = entrepeneurship.EntrepeneurshipSocials.Select(es => es.Social).Where(s => s.Id == socialDto.Id).FirstOrDefault();
                if(social == null) { 
                    social = new Social();
                }
                social.SocialTypeId = socialType.Id;
                social.UserName = socialDto.Link;

                socials.Add(social);
            }

            foreach (var social in socials)
            {
                db.Socials.AddOrUpdate(social);
                if(social.EntrepeneurshipSocials.Count == 0)
                {
                    db.EntrepeneurshipSocials.AddOrUpdate(new Models.EntrepeneurshipSocial()
                    {
                        EntrepeneurshipId = entrepeneurship.Id,
                        SocialId = social.Id
                    });
                }
            }
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/Entrepeneurships/5
        [ResponseType(typeof(Entrepeneurship))]
        public IHttpActionResult DeleteEntrepeneurship(int id)
        {
            Entrepeneurship entrepeneurship = db.Entrepeneurships.Find(id);
            if (entrepeneurship == null)
            {
                return NotFound();
            }

            db.Entrepeneurships.Remove(entrepeneurship);
            db.SaveChanges();

            return Ok(entrepeneurship);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntrepeneurshipExists(int id)
        {
            return db.Entrepeneurships.Count(e => e.Id == id) > 0;
        }
    }
}