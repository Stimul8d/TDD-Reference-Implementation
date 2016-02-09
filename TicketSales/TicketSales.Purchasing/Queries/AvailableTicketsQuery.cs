using System.Collections.Generic;
using System.Linq;
using TicketSales.Infrastructure;
using TicketSales.Infrastructure.Data;
using TicketSales.Purchasing.Domain;

namespace TicketSales.Purchasing.Queries
{
    public class AvailableTicketsQuery : IQuery<int, Ticket>
    {
        private readonly IGetAll<Ticket> ticketGetter;

        public AvailableTicketsQuery(IGetAll<Ticket> ticketGetter)
        {
            this.ticketGetter = ticketGetter;
        }

        public IEnumerable<Ticket> Execute(int eventId = 0)
        {
            return ticketGetter.All().Where(t => t.EventId == eventId);
        }
    }
}
