using System;

namespace TicketSales.Purchasing.Domain
{
    public class Order
    {
        private readonly Guid id;
        private readonly int userId;
        private readonly int eventId;
        private readonly int numberOfTickets;

        public Guid Id { get { return id; } }
        public int UserId { get { return userId; } }
        public int EventId { get { return eventId; } }
        public int NumberOfTickets { get { return numberOfTickets; } }

        public Order(Guid id, int userId, int eventId, int numberOfTickets)
        {
            this.id = id;
            this.userId = userId;
            this.eventId = eventId;
            this.numberOfTickets = numberOfTickets;
        }
    }
}
