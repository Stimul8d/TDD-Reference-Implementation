using System.Collections.Generic;
using Simple.Data;
using TicketSales.Infrastructure.Data;
using TicketSales.Purchasing.Domain;

namespace TicketSales.Purchasing.Data.Specifications
{
    public class TicketsByEventIdSpecification : ISpecification<Ticket>
    {
        public IEnumerable<Ticket> Execute(int eventId)
        {
            var db = Database.Open();
            var results = db.Tickets.FindAll(db.Tickets.EventId == eventId);
            foreach (var ticket in results)
            {
                yield return new Ticket(ticket.Id, ticket.EventId);
            }
        }
    }
}