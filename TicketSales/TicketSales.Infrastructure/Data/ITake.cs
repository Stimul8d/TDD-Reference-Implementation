using System.Collections.Generic;

namespace TicketSales.Infrastructure.Data
{
    public interface ITake<out T>
    {
        IEnumerable<T> Take(int num);
    }
}