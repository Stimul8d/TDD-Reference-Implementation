using Simple.Data;
using TicketSales.Infrastructure.Data;

namespace TicketSales.Purchasing.Data.Specifications
{
    public class TicketsByEventIdSpecification : ISpecification
    {
        public dynamic Execute(int eventId)
        {
            var db = Database.Open();
            return db.Tickets.Where(db.Tickets.EventId == eventId);
        }
    }
}