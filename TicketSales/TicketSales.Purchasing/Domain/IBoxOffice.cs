namespace TicketSales.Purchasing.Domain
{
    public interface IBoxOffice
    {
        void SellTickets(int userId, int eventId, int numberOfTickets);
    }
}