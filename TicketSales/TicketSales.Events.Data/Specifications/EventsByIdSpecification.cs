using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simple.Data;
using TicketSales.Events.Domain;
using TicketSales.Infrastructure.Data;

namespace TicketSales.Events.Data.Specifications
{
    public class EventsByIdSpecification : ISpecification<Event>
    {
        public IEnumerable<Event> Execute(int eventId)
        {
            var db = Database.Open();
            var @event = db.Events.FindById(eventId);

            yield return new Event(@event.Id, @event.Name, @event.Location);
        }
    }
}
