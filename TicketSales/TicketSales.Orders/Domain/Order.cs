using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Infrastructure;

namespace TicketSales.Orders.Domain
{
    public class Order
    {
        private readonly int id;
        private readonly int userId;
        private readonly int eventId;
        private readonly int numberOfTickets;

        public int Id { get { return id; } }
        public int UserId { get { return userId; } }
        public int EventId { get { return eventId; } }
        public int NumberOfTickets { get { return numberOfTickets; } }

        public Order(int id, int userId, int eventId, int numberOfTickets)
        {
            this.id = id;
            this.userId = userId;
            this.eventId = eventId;
            this.numberOfTickets = numberOfTickets;
        }
    }
}
