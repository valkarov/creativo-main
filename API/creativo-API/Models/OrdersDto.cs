using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace creativo_API.Models
{
    public class OrdersDto
    {
        public int Id { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int cityId { get; set; }
        public string City { get; set; }
        public string entrepeneurship { get; set; }
        public int entrepeneurshipId { get; set; }
        public string Status { get; set; }

        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }

        public List<OrderProductsDto> OrderProducts { get; set; }

        internal static OrdersDto MapToOrdersDto(Order order)
        {

            string Status = "";
            switch (order.State)
            {
                case 0:
                    Status = "Pendiente";
                    break;
                case 1:
                    Status = "En camino";
                    break;
                case 2:
                    Status = "Entregado";
                    break;
                case 3:
                    Status = "Listo Para Entrega";
                    break;
                case 4:
                    Status = "Devuelto";
                    break;

            }

            return new OrdersDto()
            {
                Id = order.Id,
                Phone = order.Phone,
                Email = order.Email,
                Address = order.address,
                cityId = order.District.Id,
                City = order.District.Name,
                entrepeneurship = order.Entrepeneurship.Name,
                entrepeneurshipId = order.EntrepeneurshipId,
                Status = Status,
                Date = order.Date,
                DeliveryDate = order.DeliveryDate,
                OrderProducts = order.OrderProducts.Select(op => new OrderProductsDto()
                {
                    Id = op.Id,
                    OrderId = op.OrderId,
                    ProductId = op.InventoryId,
                    Product = op.Inventory.Name,
                    Quantity = op.Quantity
                }).ToList()
            };
        }

        internal static Order MapToOrder(OrdersDto orderDto)
        {
            int State = 0;
            switch (orderDto.Status)
            {
                case "Pendiente":
                    State = 0;
                    break;
                case "En camino":
                    State = 1;
                    break;
                case "Entregado":
                    State = 2;
                    break;
                case "Listo Para Entrega":
                    State = 3;
                    break;
                case "Devuelto":
                    State = 4;
                    break;

            }
            return new Order()
            {
                Id = orderDto.Id,
                Phone = orderDto.Phone,
                Email = orderDto.Email,
                address = orderDto.Address,
                DistrictId = orderDto.cityId,
                EntrepeneurshipId = orderDto.entrepeneurshipId,
                State = State,
                Date = orderDto.Date,
                DeliveryDate = orderDto.DeliveryDate,
                OrderProducts = orderDto.OrderProducts.Select(op => new OrderProduct()
                {
                    Id = op.Id,
                    OrderId = op.OrderId,
                    InventoryId = op.ProductId,
                    Quantity = op.Quantity
                }).ToList()
            };
        }

    }
    public class OrderProductsDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}