using System;
using System.Collections.Generic;
using System.Linq;
using TicketSales.Events.Domain;
using TicketSales.Infrastructure;
using TicketSales.Infrastructure.Data;

namespace TicketSales.Events.Queries
{
    public class EventsQuery : IQuery<string, Event>
    {
        private readonly IGetAll<Event> eventsGetter;

        public EventsQuery(IGetAll<Event> events)
        {
            this.eventsGetter = events;
        }

        public IEnumerable<Event> Execute(string searchTerm = "")
        {
            return eventsGetter.All().Where(e =>
                string.Equals(e.Location.Trim(), searchTerm.Trim(), StringComparison.CurrentCultureIgnoreCase) ||
                string.Equals(e.Name.Trim(), searchTerm.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .ToList();
        }
    }
}
