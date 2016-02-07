using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Purchasing.Domain.Events;

namespace TicketSales.Purchasing.Domain
{
    public class BoxOffice : IBoxOffice
    {
        public void SellTickets(int userId,int eventId, int numberOfTickets)
        {
            DomainEvents.Raise(
                new TicketsPurchasedEvent(userId,eventId,numberOfTickets));
        }
    }
}
