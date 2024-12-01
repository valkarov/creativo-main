using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace creativo_API.Models
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        internal static InventoryDto MapToInventoryDto(Inventory inventory)
        {
            return new InventoryDto()
            {
                Id = inventory.Id,
                Name = inventory.Name,
                Quantity = inventory.Quantity
            };
        }
    }
}