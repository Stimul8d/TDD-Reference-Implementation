using System;
using System.Data.Odbc;
using System.Linq;
using TicketSales.Infrastructure.Data;
using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Purchasing.Domain.Events;

namespace TicketSales.Purchasing.Domain.Handlers
{
    public class TicketsPurchasedUpdateInventoryHandler : IHandle<TicketsPurchasedEvent>
    {
        private readonly IGetAll<Ticket> ticketGetter;
        private readonly IDelete<Ticket> ticketDeleter;
        private readonly ICreate<Order> orderCreater;

        public TicketsPurchasedUpdateInventoryHandler(
            IGetAll<Ticket> ticketGetter, IDelete<Ticket> ticketDeleter,
            ICreate<Order> orderCreater)
        {
            this.ticketGetter = ticketGetter;
            this.ticketDeleter = ticketDeleter;
            this.orderCreater = orderCreater;
        }

        public void Handle(TicketsPurchasedEvent purchase)
        {
            var ticketsSold = ticketGetter.All()
                .Where(t => purchase.EventId == t.EventId)
                .Take(purchase.NumberOfTickets).ToList();

            var notEnoughInventory = purchase.NumberOfTickets > ticketsSold.Count;
            if (notEnoughInventory) return;

            foreach (var ticket in ticketsSold)
            {
                ticketDeleter.Delete(ticket);
            }

            orderCreater.Create(new Order(
                Guid.NewGuid(), purchase.UserId,
                purchase.EventId, purchase.NumberOfTickets));

        }
    }
}
