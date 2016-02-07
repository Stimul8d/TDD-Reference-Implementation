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
        private IRepository<Ticket> ticketRepo;

        public AvailableTicketsQuery(IRepository<Ticket> ticketRepo)
        {
            this.ticketRepo = ticketRepo;
        }

        public IEnumerable<Ticket> Execute(int eventId = 0)
        {
            return ticketRepo.All().Where(t => t.EventId == eventId);
        }
    }
}
