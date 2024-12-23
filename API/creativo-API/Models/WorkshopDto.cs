﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace creativo_API.Models
{
    public class WorkshopRequestDto
    {
        public int IdEntrepreneurship { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public float Price { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int IdWorkshop { get; set; }
        
        internal static Workshop MapToWorkshop(CreativoDBV2Entities db, WorkshopRequestDto workshopDto)
        {
            Workshop workshop;
            if(workshopDto.IdWorkshop != 0)
                workshop = db.Workshops.Find(workshopDto.IdWorkshop);
            else 
                workshop = new Workshop();
            workshop.Name = workshopDto.Name;
            workshop.Date = workshopDto.Date;
            workshop.Location = workshopDto.Location;
            workshop.Price = workshopDto.Price;
            workshop.Link = workshopDto.Link;
            workshop.WorkshopType = db.WorkshopTypes.Where(d => d.Name == workshopDto.Type).FirstOrDefault();
            workshop.Description = workshopDto.Description;
            workshop.EntrepeneurshipId = workshopDto.IdEntrepreneurship;

            return workshop;
        }
        internal static WorkshopRequestDto workshopRequestDto(Workshop workshop)
        {
            return new WorkshopRequestDto()
            {
                Name = workshop.Name,
                Date = workshop.Date,
                Location = workshop.Location,
                Price = workshop.Price,
                Link = workshop.Link,
                Type = workshop.WorkshopType.Name,
                Description = workshop.Description,
                IdEntrepreneurship = workshop.EntrepeneurshipId,
                IdWorkshop = workshop.Id
            };
        }
    }
    public class WorkshopClientRequestDto
    {
        public int Id { get; set; }
        public string IdClient { get; set; }
        public int IdWorkshop { get; set; }
        public string LastDigits { get; set; }
        public string Owner { get; set; }
        public float Price { get; set; }
        public string State { get; set; }

        internal static  WorkShopClient MapToWorkshopClient(CreativoDBV2Entities db, WorkshopClientRequestDto workshopClientDto)
        {
            WorkShopClient workshopClient;
            if (workshopClientDto.Id != 0)
                workshopClient = db.WorkShopClients.Find(workshopClientDto.Id);
            else
                workshopClient = new WorkShopClient();
            workshopClient.UserId = int.Parse(workshopClientDto.IdClient);
            workshopClient.WorkshopId = workshopClientDto.IdWorkshop;
            workshopClient.price = workshopClientDto.Price;
            workshopClient.State = workshopClientDto.State;
            workshopClient.lastDigits = workshopClientDto.LastDigits;
            return workshopClient;
        }

        internal static WorkshopClientRequestDto MapToWorkshopClientDto(WorkShopClient workshopClient)
        {
            return new WorkshopClientRequestDto()
            {
                Id = workshopClient.Id,
                IdClient = workshopClient.UserId.ToString(),
                IdWorkshop = workshopClient.WorkshopId,
                LastDigits = workshopClient.lastDigits,
                Owner = workshopClient.User.FirstName + " " + workshopClient.User.LastName,
                Price = workshopClient.price,
                State = workshopClient.State
            };
        }
    }
}