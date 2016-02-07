using System.Diagnostics;
using TicketSales.Infrastructure.DomainEvents;

namespace TicketSales.Purchasing.Domain.Events
{
    public class TicketsPurchasedEvent : IDomainEvent
    {
        private readonly int userId;
        private readonly int eventId;
        private readonly int numberOfTickets;

        public int UserId
        {
            get { return userId; }   
        }

        public int EventId
        {
            get { return eventId; }
        }

        public int NumberOfTickets
        {
            get { return numberOfTickets; }
        }

        [DebuggerStepThrough]
        public TicketsPurchasedEvent(int userId, int eventId, int numberOfTickets)
        {
            this.userId = userId;
            this.numberOfTickets = numberOfTickets;
            this.eventId = eventId;
        }
    }
}
