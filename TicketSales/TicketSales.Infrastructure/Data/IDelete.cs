namespace TicketSales.Infrastructure.Data
{
    public interface IDelete<in T>
    {
        void Delete(T item);
    }
}