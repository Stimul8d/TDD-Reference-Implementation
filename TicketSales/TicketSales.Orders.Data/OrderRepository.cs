using System.Collections.Generic;
using Simple.Data;
using TicketSales.Infrastructure.Data;
using TicketSales.Orders.Domain;

namespace TicketSales.Orders.Data
{
    public class OrderRepository : IRepository<Order>
    {
        public IEnumerable<Order> All()
        {
            var db = Database.Open();
            foreach (var order in db.Orders.All())
            {
                yield return new Order(order.Id, order.UserId, order.EventId, order.NumberOfTickets);
            }
        }

        public void Delete(Order item)
        {
            var db = Database.Open();
            db.DeleteById(item.Id);
        }
    }
}