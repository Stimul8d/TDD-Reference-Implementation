namespace TicketSales.Infrastructure.Data
{
    public interface ICreate<in T>
    {
        void Create(T item);
    }
}