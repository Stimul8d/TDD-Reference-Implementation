using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Infrastructure.DomainEvents;

namespace TicketSales.Purchasing.Domain.Events
{
    public class InventoryUpdatedEvent : IDomainEvent
    {
        private readonly IEnumerable<Ticket> ticketsLeft;

        public IEnumerable<Ticket> TicketsLeft
        {
            get { return ticketsLeft; }
        }

        public InventoryUpdatedEvent(IEnumerable<Ticket> ticketsLeft )
        {
            this.ticketsLeft = ticketsLeft;
        }
    }
}
