using System;
using System.Collections.Generic;
using System.Linq;
using TicketSales.Infrastructure;
using TicketSales.Infrastructure.Data;
using TicketSales.Purchasing.Domain;

namespace TicketSales.Purchasing.Queries
{
    public class AvailableTicketsQuery : IQuery<int, Ticket>
    {
        private IGetAll<Ticket> _ticketGetter;

        public AvailableTicketsQuery(IGetAll<Ticket> ticketGetter)
        {
            this._ticketGetter = ticketGetter;
        }

        public IEnumerable<Ticket> Execute(int eventId = 0)
        {
            return _ticketGetter.All().Where(t => t.EventId == eventId);
        }
    }
}
