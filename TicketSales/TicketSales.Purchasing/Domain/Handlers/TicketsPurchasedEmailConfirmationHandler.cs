using System;
using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Purchasing.Domain.Events;

namespace TicketSales.Purchasing.Domain.Handlers
{
    public class TicketsPurchasedEmailConfirmationHandler : IHandle<TicketsPurchasedEvent>
    {
        public void Handle(TicketsPurchasedEvent t)
        {
            Console.Write("I Just Sent An Email!!");
        }
    }
}