using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace creativo_API.Models
{
    public class EntrepeneurshipDto
    {
        public enum EntrepeneurshipsState
        {
            Pendiente = 1,
            Aprobado = 2
        }
        public class EntrepeneurshipSocialRequest
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Link { get; set; }
        }

            public class EntrepeneurshipRequestDto
        {
            public string IdType { get; set; }
            public string Name { get; set; }
            public int IdEntrepreneurship { get; set; }
            public string Type { get; set; }
            public string Email { get; set; }
            public string Sinpe { get; set; }
            public string Phone { get; set; }
            public string Description { get; set; }
            public string District { get; set; }
            public string Province { get; set; }
            public string Canton { get; set; }
            public string Reason { get; set; }
            public string State { get; set; }
            public EntrepeneurshipSocialRequest[] Socials { get; set; }

            internal static EntrepeneurshipRequestDto MapFromEntrepeneurhip(Entrepeneurship entrepeneurship)
            {
                return new EntrepeneurshipRequestDto()
                {
                    IdType = entrepeneurship.EntrepeneurshipTypeId.ToString(),
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
                    Reason = entrepeneurship.Reason,
                    State = entrepeneurship.state.ToString(),
                    Socials = entrepeneurship.EntrepeneurshipSocials.Select(s => new EntrepeneurshipSocialRequest()
                    {
                        Id = s.Id,
                        Type = s.Social.SocialType.Name,
                        Link = s.Social.UserName
                    }).ToArray()
                };
            }
        }
    }
}