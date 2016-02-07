using System.Collections.Generic;
using Simple.Data;
using TicketSales.Events.Domain;
using TicketSales.Infrastructure.Data;

namespace TicketSales.Events.Data
{
    public class EventRepository : IGetAll<Event>
    {
        public IEnumerable<Event> All()
        {
            dynamic db = Database.Open();
            foreach (var @event in db.Events.All())
            {
                yield return new Event(@event.id, @event.Name, @event.Location);
            }
        }
    }
}
