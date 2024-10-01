using creativo_API.Models;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using static creativo_API.Models.UserDto;

namespace creativo_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private CreativoDBV2Entities db = new CreativoDBV2Entities();

        [HttpPost]
        [Route("api/Users/Login")]
        public IHttpActionResult UserLogin(UserLoginDto user)
        {
            User userLogin = db.Users.Where(u => u.UserName == user.Username && u.Password == user.Password).FirstOrDefault();
            if(userLogin == null)
            {
                return BadRequest("Login Failed");
            }
            return Ok(userLogin);
        }

        [HttpPost]
        public IHttpActionResult PostClient(ClientRequestDto user)
        {
            if (user == null)
            {
                return BadRequest("Invalid data.");
            }
            Role clientRole = db.Roles.Where(r => r.Name == user.Role).FirstOrDefault();
            User newUser = new User();
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.Cedula = user.IdClient;
            newUser.UserName = user.Username;
            newUser.Phone = user.Phone;
            newUser.Email = user.Email;
            newUser.Password = user.Password;
            newUser.District = db.Districts.Where(d => d.Name == user.District).FirstOrDefault();
            if (clientRole == null)
            {
                return BadRequest("Role not found.");
            }
            newUser.Role = clientRole;
            
            db.Users.Add(newUser);
            db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("api/Users/{Username}")]
        public IHttpActionResult GetUserByUsername(string username)
        {
            User user = db.Users.Where(u => u.UserName == username).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
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
    }
}
