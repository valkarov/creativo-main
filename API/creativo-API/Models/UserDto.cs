using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace creativo_API.Models
{
    public class SessionDto
    {
        public string session { get; set; }
        public string userName { get; set; }
        public bool isAdmin { get; set; }
        public bool isEmprendedor { get; set; }
        public bool isRepartidor { get; set; }


    }
    public class UserSessionLoginDto
    {
        public string token { get; set; }
        public string[] roles { get; set; }
    }
    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class ClientRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdClient { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Canton { get; set; }
        public string Role { get; set; }
        internal static User MapToUser(CreativoDBV2Entities db, ClientRequestDto user)
        {
            return new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Cedula = user.IdClient,
                UserName = user.Username,
                Phone = user.Phone,
                Email = user.Email,
                Password = user.Password,
                District = db.Districts.Where(d => d.Name == user.District).FirstOrDefault(),
            };
        }
    }
    public class UserResponseDto
    {
        public string IdClient { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Province { get; set; }
        public string Canton { get; set; }
        public string District { get; set; }
        public string Role { get; set; }

        public static User MapToUser(CreativoDBV2Entities db, UserResponseDto user)
        {
            return new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Cedula = user.IdClient,
                UserName = user.Username,
                Phone = user.Phone,
                Email = user.Email,
                Password = user.Password,
                District = db.Districts.Where(d => d.Name == user.District).FirstOrDefault(),
            };
        }
    }
}