using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Purchasing.Domain.Events;

namespace TicketSales.Purchasing.Domain.Handlers
{
    public class UpdateInventoryHandler : IHandle<TicketsPurchasedEvent>
    {
        private List<Ticket> tickets;

        public IEnumerable<Ticket> Tickets
        {
            get { return tickets; }
        }

        public UpdateInventoryHandler(IEnumerable<Ticket> tickets)
        {
            this.tickets = tickets.ToList();
        }

        public void Handle(TicketsPurchasedEvent purchase)
        {
            var ticketsSold = tickets
                .Where(t => purchase.EventId == t.EventId)
                .Take(purchase.NumberOfTickets);

            foreach (var ticket in ticketsSold) tickets.Remove(ticket);
        }
    }
}
