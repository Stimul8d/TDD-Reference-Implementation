using System;
using System.Collections.Generic;
using System.Linq;
using TicketSales.Events.Domain;
using TicketSales.Infrastructure;

namespace TicketSales.Events.Queries
{
    public class EventsSearch : IQuery<string, Event>
    {
        private IEnumerable<Event> events;

        public EventsSearch() : this(new List<Event>()) { }

        public EventsSearch(IEnumerable<Event> events)
        {
            need to make an events repo of some sort
            this.events = events;
        }

        public IEnumerable<Event> Execute(string searchTerm = "")
        {
            return events.Where(e =>
                string.Equals(e.Location.Trim(), searchTerm.Trim(), StringComparison.CurrentCultureIgnoreCase) ||
                string.Equals(e.Name.Trim(), searchTerm.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .ToList();
        }
    }
}
