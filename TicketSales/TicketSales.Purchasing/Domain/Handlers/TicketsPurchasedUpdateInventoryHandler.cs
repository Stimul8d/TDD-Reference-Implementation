using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicketSales.Infrastructure.Data;
using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Purchasing.Domain.Events;

namespace TicketSales.Purchasing.Domain.Handlers
{
    public class TicketsPurchasedUpdateInventoryHandler : IHandle<TicketsPurchasedEvent>
    {
        private readonly List<Ticket> tickets;

        public IEnumerable<Ticket> Tickets
        {
            get { return tickets; }
        }

        public TicketsPurchasedUpdateInventoryHandler(IRepository<Ticket> ticketRepo)
        {
            tickets = ticketRepo.All().ToList();
        }

        public void Handle(TicketsPurchasedEvent purchase)
        {
            var ticketsSold = tickets
                .Where(t => purchase.EventId == t.EventId)
                .Take(purchase.NumberOfTickets);

            foreach (var ticket in ticketsSold) tickets.Remove(ticket);

            DomainEvents.Raise(new InventoryUpdatedEvent(tickets));
        }
    }
}
