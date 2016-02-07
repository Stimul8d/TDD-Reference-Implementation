using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simple.Data;
using TicketSales.Infrastructure.Data;
using TicketSales.Purchasing.Domain;

namespace TicketSales.Purchasing.Data
{
    public class TicketRepository : IRepository<Ticket>
    {
        public IEnumerable<Ticket> All()
        {
            var db = Database.Open();
            foreach (var ticket in db.Tickets.All())
            {
                yield return new Ticket(ticket.Id, ticket.EventId);
            }
        }

        public void Delete(Ticket item)
        {
            var db = Database.Open();
            db.Tickets.DeleteById(item.Id);
            var x = All();
        }
    }
}
