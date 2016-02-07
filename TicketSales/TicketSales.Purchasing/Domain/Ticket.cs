using System;
using System.Diagnostics;

namespace TicketSales.Purchasing.Domain
{
    [DebuggerDisplay("ID:{Id}, EVENTID:{EventId}")]
    public class Ticket
    {
        private readonly int eventId;
        private readonly Guid id;

        public int EventId
        {
            get { return eventId; }
        }

        public Guid Id
        {
            get { return id; }
        }

        public Ticket(Guid id, int eventId)
        {
            this.eventId = eventId;
            this.id = id;
        }

    }
}
