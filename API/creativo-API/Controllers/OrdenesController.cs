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
    public class OrdenesController : ApiController
    {
        private CreativoDBV2Entities db = new CreativoDBV2Entities();
        private SessionService sessionService = SessionService.Instance;

        // GET api/ordenes

        public IEnumerable<OrdersDto> Get()
        {
            List<Order> orders = db.Orders.ToList();
            List<OrdersDto> ordersDto = new List<OrdersDto>();
            foreach (Order order in orders)
            {
                ordersDto.Add(OrdersDto.MapToOrdersDto(order));
            }

            return ordersDto;


        }

        // GET api/ordenes/5
        public OrdersDto Get(int id)
        {
            Order order = db.Orders.FirstOrDefault(e => e.Id == id);
            if (order == null)
            {
                return null;
            }
            return OrdersDto.MapToOrdersDto(order);
        }
        public void Post([FromBody] OrdersDto order)
        {
            Order newOrder = OrdersDto.MapToOrder(order);
            newOrder.District = db.Districts.FirstOrDefault(e => e.Name == order.City);
            newOrder.Date = DateTime.Now;

            User deliveryman = db.Users.Where(x => x.UserRoles.Any(ur => ur.Role.Name == "REPARTIDOR") && x.District.Id == newOrder.DistrictId).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            if (deliveryman == null)
                deliveryman = db.Users.Where(x => x.UserRoles.Any(ur => ur.Role.Name == "REPARTIDOR") && x.District.CantonId == newOrder.District.CantonId).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            if (deliveryman == null)
                deliveryman = db.Users.Where(x => x.UserRoles.Any(ur => ur.Role.Name == "REPARTIDOR") && x.District.Canton.ProvinceId == newOrder.District.Canton.Province.Id).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            if (deliveryman == null)
                deliveryman = db.Users.Where(x => x.UserRoles.Any(ur => ur.Role.Name == "REPARTIDOR")).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            newOrder.DeliveryManId = deliveryman.Id;
            newOrder.User = deliveryman;

            //TODO: after deliveryman is implemented, change this
            newOrder.DeliveryDate = DateTime.Now;
            newOrder.State = 2;

            db.Orders.Add(newOrder);
            db.SaveChanges();
        }
        // DELETE api/ordenes/5
        public void Delete(int id)
        {
            Order order = db.Orders.FirstOrDefault(e => e.Id == id);
            db.OrderProducts.RemoveRange(order.OrderProducts);
            db.Orders.Remove(order);
            db.SaveChanges();
        }

        //GET api/ordenes/byEntrepeneurship/5
        [Route("api/ordenes/byEntrepeneurship/{id}")]
        public IEnumerable<OrdersDto> GetByEntrepeneurship(int id)
        {
            List<Order> orders = db.Orders.Where(e => e.EntrepeneurshipId == id).ToList();
            List<OrdersDto> ordersDto = new List<OrdersDto>();
            foreach (Order order in orders)
            {
                ordersDto.Add(OrdersDto.MapToOrdersDto(order));
            }

            return ordersDto;
        }

        //PUT api/ordenes/{id}/status/{status}
        [HttpPut]
        [Route("api/ordenes/{id}/status/{status}")]
        public void changeStatus(int id, string status)
        {
            Order order = db.Orders.FirstOrDefault(
                e => e.Id == id
            );
            order.State = status == "Entregado" ? 2 : status == "En camino" ? 1 : status == "Listo Para Entrega" ? 3 : status == "Devuelto" ? 4 : 0;
            db.SaveChanges();
        }


    }
}
