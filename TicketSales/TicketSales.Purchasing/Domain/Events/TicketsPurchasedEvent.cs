using TicketSales.Infrastructure.DomainEvents;

namespace TicketSales.Purchasing.Domain.Events
{
    public class TicketsPurchasedEvent : IDomainEvent
    {
        private readonly int eventId;
        private readonly int numberOfTickets;

        public int EventId
        {
            get { return eventId; }
        }

        public int NumberOfTickets
        {
            get { return numberOfTickets; }
        }

        public TicketsPurchasedEvent(int eventId, int numberOfTickets)
        {
            this.numberOfTickets = numberOfTickets;
            this.eventId = eventId;
        }
    }
}
