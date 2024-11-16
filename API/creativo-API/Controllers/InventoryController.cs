using creativo_API.Models;
using creativo_API.Services;
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
    public class InventoryController : ApiController
    {
        private CreativoDBV2Entities db = new CreativoDBV2Entities();
        private SessionService sessionService = SessionService.Instance;


        // GET api/inventory
        public IEnumerable<InventoryDto> Get()
        {
            List<Inventory> inventories = db.Inventories.ToList();
            List<InventoryDto> inventoryDtos = new List<InventoryDto>();
            inventories.ForEach(i => inventoryDtos.Add(InventoryDto.MapToInventoryDto(i)));

            return inventoryDtos;
        }

        //Post api/inventory
        public void Post([FromBody] Inventory inventory)
        {
            db.Inventories.Add(inventory);
            db.SaveChanges();
        }

        // PUT api/inventory/5
        public void Put(int id, [FromBody] Inventory inventory)
        {
            Inventory entity = db.Inventories.FirstOrDefault(e => e.Id == id);
            entity.Name = inventory.Name;
            entity.Quantity = inventory.Quantity;
            db.SaveChanges();
        }
        public void Delete(int id) {
            Inventory inventory = db.Inventories.FirstOrDefault(e => e.Id == id);
            db.Inventories.Remove(inventory);
            db.SaveChanges();
        }

    }
}
