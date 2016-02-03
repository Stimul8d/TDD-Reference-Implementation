using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSales.Purchasing.Domain
{
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

        public Ticket(int eventId)
        {
            this.eventId = eventId;
            id = Guid.NewGuid();
        }

    }
}
