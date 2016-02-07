using System.Collections.Generic;
using Simple.Data;
using TicketSales.Infrastructure.Data;
using TicketSales.Purchasing.Domain;

namespace TicketSales.Purchasing.Data
{
    public class OrderRepository : IGetAll<Order>, ICreate<Order>
    {
        public IEnumerable<Order> All()
        {
            var db = Database.Open();
            foreach (var order in db.Orders.All())
            {
                yield return new Order(order.Id, order.UserId, order.EventId, order.NumberOfTickets);
            }
        }

        public void Create(Order item)
        {
            var db = Database.Open();
            db.Orders.Insert(Id: item.Id, UserId: item.UserId, EventId: item.EventId,
                NumberOfTickets: item.NumberOfTickets);
        }
    }
}