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
        private readonly IRepository<Event> eventsRepo;

        public EventsQuery(IRepository<Event> events)
        {
            this.eventsRepo = events;
        }

        public IEnumerable<Event> Execute(string searchTerm = "")
        {
            return eventsRepo.All().Where(e =>
                string.Equals(e.Location.Trim(), searchTerm.Trim(), StringComparison.CurrentCultureIgnoreCase) ||
                string.Equals(e.Name.Trim(), searchTerm.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .ToList();
        }
    }
}
