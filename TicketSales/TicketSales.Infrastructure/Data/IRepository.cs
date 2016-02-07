using System.Collections.Generic;

namespace TicketSales.Infrastructure.Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> All();
        void Delete(T item);
    }
}