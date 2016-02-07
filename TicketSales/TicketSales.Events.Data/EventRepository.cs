using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simple.Data;
using TicketSales.Events.Domain;
using TicketSales.Infrastructure.Data;

namespace TicketSales.Events.Data
{
    public class EventRepository : IRepository<Event>
    {
        public IEnumerable<Event> All()
        {
            dynamic db = Database.Open();
            foreach (var @event in db.Events.All())
            {
                yield return new Event(@event.Name,@event.Location);
            }
        }

        public void Delete(Event item)
        {
            dynamic db = Database.Open();
            db.Delete(Name: item.Name, Location: item.Location);
        }
    }
}
