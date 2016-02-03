using System;
using System.Collections.Generic;
using System.Linq;
using TicketSales.Infrastructure;
using TicketSales.Purchasing.Domain;

namespace TicketSales.Purchasing.Queries
{
    public class AvailableTicketsQuery : IQuery<int, Ticket>
    {
        private readonly IEnumerable<Ticket> tickets;

        public AvailableTicketsQuery(IEnumerable<Ticket> tickets)
        {
            this.tickets = tickets;
        }

        public IEnumerable<Ticket> Execute(int eventId = 0)
        {
            return tickets.Where(t => t.EventId == eventId);
        }
    }
}
