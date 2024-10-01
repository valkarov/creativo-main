using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace creativo_API.Models
{
    public class UserDto
    {
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
        }
    }
}