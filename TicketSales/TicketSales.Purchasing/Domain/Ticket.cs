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

        public int EventId
        {
            get { return eventId; }
        }

        public Ticket(int eventId)
        {
            this.eventId = eventId;
        }
    }
}
