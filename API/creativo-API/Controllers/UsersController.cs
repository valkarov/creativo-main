using creativo_API.Models;
using creativo_API.Services;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace creativo_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private CreativoDBV2Entities db = new CreativoDBV2Entities();
        private SessionService sessionService = SessionService.Instance;
        [HttpPost]
        [Route("api/Users/Login")]
        public IHttpActionResult UserLogin(UserLoginDto user)
        {
            User userLogin = db.Users.Where(u => u.UserName == user.Username && u.Password == user.Password).FirstOrDefault();
            if (userLogin == null)
            {
                return BadRequest("Login Failed");
            }
            string session = sessionService.AddSession(userLogin.Id);
            var result = new UserSessionLoginDto()
            {
                token = session,
                roles = userLogin.UserRoles.Select(ur => ur.Role.Name).ToArray()
            };
            return Ok(result);
        }

        [HttpPost]
        [Route("api/Users/Login/Session")]
        public IHttpActionResult UserLoginSession(UserSessionRequestDto sessionRequest)
        {
            int session = sessionService.GetSession(sessionRequest.session);
            if (session != -1)
                return Ok(session);
            else
                return Unauthorized();
        }
        [HttpPost]
        public IHttpActionResult PostClient(ClientRequestDto user)
        {
            if (user == null)
            {
                return BadRequest("Invalid data.");
            }
            Role role = db.Roles.Where(r => r.Name == user.Role).FirstOrDefault();

            User newUser = ClientRequestDto.MapToUser(db, user);
            if (role == null)
            {
                return BadRequest("Role not found.");
            }
            UserRole userRole = new UserRole() { Role = role, User = newUser };
            newUser.Role = role;

            db.UserRoles.Add(userRole);
            db.Users.Add(newUser);
            db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("api/Users/{Cedula}")]
        public IHttpActionResult GetUserByCedulaOrSession(string cedula)
        {
            User user = db.Users.Where(u => u.Cedula == cedula).FirstOrDefault();
            if (user == null)
            {
                int userId = sessionService.GetSession(cedula);
                if (userId == -1)
                {
                    return NotFound();
                }
                user = db.Users.Find(userId);
            }
            UserResponseDto response = new UserResponseDto()
            {
                IdClient = user.Cedula,
                Username = user.UserName,
                Password = user.Password,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Province = user.District.Canton.Province.Name,
                District = user.District.Name,
                Canton = user.District.Canton.Name,
                Role = user.Role.Name

            };
            return Ok(response);
        }
        [HttpPut]
        [Route("api/Users/{Cedula}")]
        public IHttpActionResult UpdateUserByCedula(ClientRequestDto User)
        {
            User user = db.Users.Where(u => u.Cedula == User.IdClient).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            user.FirstName = User.FirstName;
            user.LastName = User.LastName;
            user.UserName = User.Username;
            user.Phone = User.Phone;
            user.Email = User.Email;
            user.Password = User.Password;
            user.District = db.Districts.Where(d => d.Name == User.District).FirstOrDefault();
            Role clientRole = db.Roles.Where(r => r.Name == User.Role).FirstOrDefault();
            if (clientRole == null)
            {
                return BadRequest("Role not found.");
            }
            user.Role = clientRole;
            db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("api/Admins")]
        public IHttpActionResult getAdmins()
        {

            List<User> admins = db.Users.Where(u => u.Role.Name == "Admin").ToList();
            List<UserResponseDto> response = new List<UserResponseDto>();
            foreach (User admin in admins)
            {
                UserResponseDto user = new UserResponseDto()
                {
                    IdClient = admin.Cedula,
                    Username = admin.UserName,
                    Password = admin.Password,
                    Email = admin.Email,
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Phone = admin.Phone,
                    Province = admin.District.Canton.Province.Name,
                    District = admin.District.Name,
                    Canton = admin.District.Canton.Name,
                    Role = admin.Role.Name
                };
                response.Add(user);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("api/Users/User")]
        public IHttpActionResult getUserBySession(){
            string authorization = Request.Headers.GetValues("Authorization").FirstOrDefault();
            string[] strings = authorization.Split(' ');
            int userId = sessionService.GetSession(strings[1]);

            var user = db.Users.Find(userId);
            UserResponseDto userResponse = new UserResponseDto()
            {
                IdClient = user.Cedula,
                Username = user.UserName,
                Password = user.Password,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Province = user.District.Canton.Province.Name,
                District = user.District.Name,
                Canton = user.District.Canton.Name,
                Role = user.Role.Name
            };
            return Ok(userResponse);
        }
    }
}
