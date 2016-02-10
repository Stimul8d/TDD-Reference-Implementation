using System.Collections;
using System.Collections.Generic;

namespace TicketSales.Infrastructure.Data
{
    public interface ISpecification<out T>
    {
        IEnumerable<T> Execute(int eventId);
    }
}