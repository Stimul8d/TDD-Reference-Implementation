using System.Collections.Generic;

namespace TicketSales.Infrastructure
{
    public interface IQuery<in S, out T>
    {
        IEnumerable<T> Execute(S searchTerm = default(S));
    }
}