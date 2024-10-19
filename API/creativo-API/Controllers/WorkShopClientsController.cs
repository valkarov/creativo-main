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

namespace creativo_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WorkShopClientsController : ApiController
    {
        private CreativoDBV2Entities db = new CreativoDBV2Entities();
        private SessionService sessionService = SessionService.Instance;
        private MailService mailService = new MailService();
        private PDFService pdfService = new PDFService();
        // GET: api/WorkShopClients
        public IQueryable<WorkShopClient> GetWorkShopClients()
        {
            return db.WorkShopClients;
        }

        [HttpGet]
        [Route("api/WorkShopClients/byEntre/{id}")]
        public List<WorkshopClientRequestDto> GetWorkShopClientsByEntre(int id)
        {
            
            var workshopClientes = db.WorkShopClients.Where(w => w.Workshop.EntrepeneurshipId == id).ToList();
            List<WorkshopClientRequestDto> workshopClientDtos = new List<WorkshopClientRequestDto>();
            foreach (var workshopClient in workshopClientes)
            {
                workshopClientDtos.Add(WorkshopClientRequestDto.MapToWorkshopClientDto(workshopClient));
            }
            return workshopClientDtos;
        }
        [HttpGet]
        [Route("api/WorkshopClients/GetUser/{id}")]
        public UserResponseDto GetuserFromWorkshopClient(int id)
        {
            var workShopClient = db.WorkShopClients.Find(id);
            UserResponseDto user = UserResponseDto.MapToUserResponseDto(workShopClient.User);
            return user;
        }
        // GET: api/WorkShopClients/5
        [ResponseType(typeof(WorkShopClient))]
        public IHttpActionResult GetWorkShopClient(int id)
        {
            WorkShopClient workShopClient = db.WorkShopClients.Find(id);
            if (workShopClient == null)
            {
                return NotFound();
            }

            return Ok(workShopClient);
        }

        // PUT: api/WorkShopClients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorkShopClient(int id, WorkshopClientRequestDto workshopClientRequestDto)
        {
           
           var workshopClient = WorkshopClientRequestDto.MapToWorkshopClient(db, workshopClientRequestDto);
           
            db.WorkShopClients.AddOrUpdate(workshopClient);
            if (id != workshopClient.Id)
            {
                return BadRequest();
            }
            if (workshopClient.State == "Aceptado")
            {
                string filename = $"Factura-{workshopClient.User.FirstName}-{workshopClient.Id}";
                string text = $"factura {workshopClient.Id} por ${workshopClient.price} para ${workshopClient.User.FirstName} con cedula ${workshopClient.User.Cedula}";
                pdfService.createPDF(filename, text);
            }
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/WorkShopClients
        [ResponseType(typeof(WorkShopClient))]
        public IHttpActionResult PostWorkShopClient(WorkshopClientRequestDto workShopClientDto)
        {
            string authorization = Request.Headers.GetValues("Authorization").FirstOrDefault();
            string[] strings = authorization.Split(' ');
            int userId = sessionService.GetSession(strings[1]);
            if(userId == -1)
            {
                return Unauthorized();
            }
            workShopClientDto.IdClient = userId.ToString();
            WorkShopClient workShopClient = WorkshopClientRequestDto.MapToWorkshopClient(db,workShopClientDto);

            db.WorkShopClients.Add(workShopClient);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = workShopClient.Id }, workShopClient);
        }

        // DELETE: api/WorkShopClients/5
        [ResponseType(typeof(WorkShopClient))]
        public IHttpActionResult DeleteWorkShopClient(int id)
        {
            WorkShopClient workShopClient = db.WorkShopClients.Find(id);
            if (workShopClient == null)
            {
                return NotFound();
            }

            db.WorkShopClients.Remove(workShopClient);
            db.SaveChanges();

            return Ok(workShopClient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkShopClientExists(int id)
        {
            return db.WorkShopClients.Count(e => e.Id == id) > 0;
        }
    }
}