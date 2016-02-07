using System.Collections.Generic;

namespace TicketSales.Infrastructure.Data
{
    public interface IGetAll<out T>
    {
        IEnumerable<T> All();
    }
}