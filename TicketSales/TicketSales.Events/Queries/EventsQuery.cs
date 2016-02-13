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
            var events = eventsGetter.All();

            return events.Where(e =>
                e.Location.ToUpper().Trim().Contains(searchTerm.Trim().ToUpper()) ||
                e.Name.Trim().ToUpper().Contains(searchTerm.Trim().ToUpper()))
                .ToList();
        }
    }
}
