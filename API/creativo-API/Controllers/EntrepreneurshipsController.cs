using creativo_API.Models;
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace creativo_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EntrepreneurshipsController : ApiController
    {
        private creativoDBEntity db = new creativoDBEntity();

        // GET: api/Entrepreneurships
        public IQueryable<Entrepreneurship> GetEntrepreneurships()
        {
            return db.Entrepreneurships;
        }


        // GET: api/Entrepreneurships/Solicitudes
        [HttpGet]
        [Route("api/Entrepreneurships/Solicitudes")]
        public IQueryable<Entrepreneurship> GetSolicitudes()
        {
            return db.Entrepreneurships.Where(e => e.State == "Pendiente");
        }

        // GET: api/Clients/byUser/5
        [HttpGet]
        [Route("api/Entrepreneurships/User/{user}")]
        [ResponseType(typeof(Entrepreneurship))]
        public IHttpActionResult GetEntreUser(string user)
        {
            var entre = db.Entrepreneurships.FirstOrDefault(c => c.Username == user);

            if (entre == null)
            {
                return NotFound();
            }

            return Ok(entre);
        }


        // GET: api/Entrepreneurships/5
        [ResponseType(typeof(Entrepreneurship))]
        public IHttpActionResult GetEntrepreneurship(int id)
        {
            Entrepreneurship entrepreneurship = db.Entrepreneurships.Find(id);
            if (entrepreneurship == null)
            {
                return NotFound();
            }

            return Ok(entrepreneurship);
        }

        // GET: api/Entrepreneurships/byId/5
        [HttpGet]
        [Route("api/Entrepreneurships/byId/{id}")]
        [ResponseType(typeof(Entrepreneurship))]
        public IHttpActionResult GetEntrepreneurshipById(int id)
        {
            if (!IdExists(id))
            {
                return BadRequest("No Encontrado");
            }

            return Ok();
        }
        // GET: api/Entrepreneurships/byUser/5
        [HttpGet]
        [Route("api/Entrepreneurships/byUser/{user}")]
        [ResponseType(typeof(Entrepreneurship))]
        public IHttpActionResult GetEntrepreneurshipByUser(string user)
        {
            if (!UserExists(user))
            {
                return BadRequest("No Encontrado");
            }

            return Ok();
        }

        // GET: api/Entrepreneurships/byEmail/5
        [HttpGet]
        [Route("api/Entrepreneurships/byEmail/{email}")]
        [ResponseType(typeof(Entrepreneurship))]
        public IHttpActionResult GetEntrepreneurshipByEmail(string email)
        {
            if (!EmailExistsPointless(email))
            {
                return BadRequest("No Encontrado");
            }

            return Ok();
        }


        // PUT: api/Entrepreneurships/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrepreneurship(int id, Entrepreneurship entrepreneurship)
        {
            // Buscar la entidad existente en la base de datos
            Entrepreneurship entrepreneurshipOld = db.Entrepreneurships.Find(id);

            if (entrepreneurshipOld == null)
            {
                return NotFound();
            }

            // Condicional para enviar un correo si la condición se cumple
            if (entrepreneurshipOld.State == "Pendiente" && entrepreneurship.State == "Aceptada")
            {
                correo("" +
                    "Tu emprendimiento " + entrepreneurship.Name +
                    " ha sido Aceptado. Puedes ingresar a tu cuenta " +
                    " como emprendimiento para añadir más talleres desde tu dashboard como cliente."
                    , entrepreneurship.Email);
            }

            // Condicional para enviar un correo si la condición se cumple
            if (entrepreneurshipOld.State == "Pendiente" && entrepreneurship.State == "Rechazada")
            {
                correo("" +
                    "Tu emprendimiento " + entrepreneurship.Name +
                    " ha sido Rechazada." +
                    " Nuestros ejecutivos han dicho: '" + entrepreneurship.Reason + "'. " +
                    "¡No te desanimes!, puedes volver a enviar la solicitud y volveremos a darle un vistazo."
                    , entrepreneurship.Email);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entrepreneurship.IdEntrepreneurship)
            {
                return BadRequest();
            }

            // Actualizar los campos del objeto entrepreneurshipOld con los valores de entrepreneurship
            db.Entry(entrepreneurshipOld).CurrentValues.SetValues(entrepreneurship);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdExists(id))
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





        static void correo(string mensaje, string correo)
        {

            // Configuración del servidor SMTP de Gmail
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587, // Puerto SMTP de Gmail
                Credentials = new NetworkCredential("clubcreativo95@gmail.com", "rhslulyagacuxvbe"),
                EnableSsl = true, // Habilitar SSL
            };

            // Configuración del mensaje de correo
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("clubcreativo95@gmail.com"),
                Subject = "Actualización de tu Emprendimiento",
                Body = mensaje,
                IsBodyHtml = true // Si el cuerpo del correo es HTML
            };

            // Agregar el destinatario
            mail.To.Add(correo);

            // Enviar el correo
            smtpClient.Send(mail);
            Console.WriteLine("Correo enviado exitosamente.");


        }

        // POST: api/Entrepreneurships
        [ResponseType(typeof(Entrepreneurship))]
        public IHttpActionResult PostEntrepreneurship(Entrepreneurship entrepreneurship)
        {

            if (AnyAttributeEmpty(entrepreneurship))
            {
                return BadRequest("Hay espacios en blanco");
            }

            if (IdExists(entrepreneurship.IdEntrepreneurship))
            {
                return BadRequest("Número de cédula en uso");
            }
            if (UserExists(entrepreneurship.Username))
            {
                return BadRequest("Username en uso");
            }

            if (!EsCorreoValido(entrepreneurship.Email))
            {
                return BadRequest("Correo no válido");
            }

            if (EmailExists(entrepreneurship.Email))
            {
                return BadRequest("Correo en Uso");
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entrepreneurships.Add(entrepreneurship);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IdExists(entrepreneurship.IdEntrepreneurship))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = entrepreneurship.IdEntrepreneurship }, entrepreneurship);
        }

        // DELETE: api/Entrepreneurships/5
        [ResponseType(typeof(Entrepreneurship))]
        public IHttpActionResult DeleteEntrepreneurship(int id)
        {
            Entrepreneurship entrepreneurship = db.Entrepreneurships.Find(id);
            if (entrepreneurship == null)
            {
                return NotFound();
            }

            db.Entrepreneurships.Remove(entrepreneurship);
            db.SaveChanges();

            return Ok(entrepreneurship);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IdExists(int id)
        {
            return db.Admins.Count(e => e.IdAdmin == id) > 0 ||
                db.Clients.Count(e => e.IdClient == id) > 0 ||
                db.Entrepreneurships.Count(e => e.IdEntrepreneurship == id) > 0 ||
                db.Delivery_Persons.Count(e => e.IdDeliveryPerson == id) > 0;
        }
        private bool UserExists(string user)
        {
            return db.Admins.Count(e => e.Username == user) > 0 ||
               db.Clients.Count(e => e.Username == user) > 0 ||
               db.Entrepreneurships.Count(e => e.Username == user) > 0 ||
               db.Delivery_Persons.Count(e => e.Username == user) > 0;

        }

        static bool EsCorreoValido(string correo)
        {
            string patron = @"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,6}$";
            return Regex.IsMatch(correo, patron);
        }


        private bool EmailExists(string email)
        {
            return
               db.Clients.Count(e => e.Email == email) > 0 ||
               db.Entrepreneurships.Count(e => e.Email == email) > 0 ||
               db.Delivery_Persons.Count(e => e.Email == email) > 0;

        }

        private bool EmailExistsPointless(string email)
        {
            return
               db.Clients.Count(e => e.Email.Replace(".", "") == email) > 0 ||
               db.Entrepreneurships.Count(e => e.Email.Replace(".", "") == email) > 0 ||
               db.Delivery_Persons.Count(e => e.Email.Replace(".", "") == email) > 0;

        }

        private bool AnyAttributeEmpty(Entrepreneurship entrepreneurship)
        {
            // Verificar cada propiedad del objeto Entrepreneurship
            // Devolver true si alguna propiedad es una cadena vacía, de lo contrario, devolver false
            return string.IsNullOrEmpty(entrepreneurship.Username) ||
                   string.IsNullOrEmpty(entrepreneurship.Type) ||
                   string.IsNullOrEmpty(entrepreneurship.Name) ||
                   string.IsNullOrEmpty(entrepreneurship.Email) ||
                   string.IsNullOrEmpty(entrepreneurship.Sinpe) ||
                   string.IsNullOrEmpty(entrepreneurship.Phone) ||
                   string.IsNullOrEmpty(entrepreneurship.Province) ||
                   string.IsNullOrEmpty(entrepreneurship.Canton) ||
                   string.IsNullOrEmpty(entrepreneurship.District) ||
                   string.IsNullOrEmpty(entrepreneurship.State);
        }

    }
}