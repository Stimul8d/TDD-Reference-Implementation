namespace TicketSales.Infrastructure.Data
{
    public interface ISpecification
    {
        dynamic Execute(int eventId);
    }
}