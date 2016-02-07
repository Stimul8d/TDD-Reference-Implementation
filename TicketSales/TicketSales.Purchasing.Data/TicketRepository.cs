using System.Collections.Generic;
using Simple.Data;
using TicketSales.Infrastructure.Data;
using TicketSales.Purchasing.Domain;

namespace TicketSales.Purchasing.Data
{
    public class TicketRepository : IGetAll<Ticket>, IDelete<Ticket>
    {
        public IEnumerable<Ticket> All()
        {
            var db = Database.Open();
            foreach (var ticket in db.Tickets.All())
            {
                yield return new Ticket(ticket.Id, ticket.EventId);
            }
        }

        public void Delete(Ticket item)
        {
            var db = Database.Open();
            db.Tickets.DeleteById(item.Id);
        }
    }
}
