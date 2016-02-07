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
        private IRepository<Ticket> ticketRepo;

        public TicketsPurchasedUpdateInventoryHandler(IRepository<Ticket> ticketRepo)
        {
            this.ticketRepo = ticketRepo;
        }

        public void Handle(TicketsPurchasedEvent purchase)
        {
            var ticketsSold = ticketRepo.All()
                .Where(t => purchase.EventId == t.EventId)
                .Take(purchase.NumberOfTickets).ToList();

            var notEnoughInventory = purchase.NumberOfTickets > ticketsSold.Count;
            if (notEnoughInventory) return;

            foreach (var ticket in ticketsSold) ticketRepo.Delete(ticket);
        }
    }
}
