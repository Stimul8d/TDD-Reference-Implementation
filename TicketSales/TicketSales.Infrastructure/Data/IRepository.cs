using System.Collections.Generic;

namespace TicketSales.Infrastructure.Data
{
    public interface IRepository<out T>
    {
        IEnumerable<T> All();
    }
}