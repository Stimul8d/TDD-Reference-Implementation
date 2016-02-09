using System.Collections.Generic;

namespace TicketSales.Infrastructure.Data
{
    public interface IGetNext<out T>
    {
        IEnumerable<T> GetNext(int num);
    }
}