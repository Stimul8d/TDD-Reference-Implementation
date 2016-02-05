using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Infrastructure.Data;
using TicketSales.Purchasing.Domain;

namespace TicketSales.Purchasing.Data
{
    public class AvailableTicketsRepository : IRepository<Ticket>
    {
        public IEnumerable<Ticket> All()
        {
            return Enumerable.Repeat(new Ticket(42), 42);

        }
    }
}
