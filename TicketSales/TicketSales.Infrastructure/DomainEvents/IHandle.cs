namespace TicketSales.Infrastructure.DomainEvents
{
    public interface IHandle<in T> where T : IDomainEvent
    {
        void Handle(T t);
    }
}