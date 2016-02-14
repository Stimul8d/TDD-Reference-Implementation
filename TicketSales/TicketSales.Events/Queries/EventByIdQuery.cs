using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Events.Domain;
using TicketSales.Infrastructure;
using TicketSales.Infrastructure.Data;

namespace TicketSales.Events.Queries
{
    public class EventByIdQuery : IQuery<int,Event>
    {
        private readonly ISpecification<Event> specification;

        public EventByIdQuery(ISpecification<Event> specification )
        {
            this.specification = specification;
        }

        public IEnumerable<Event> Execute(int searchTerm = 0)
        {
            return specification.Execute(searchTerm);
        }
    }
}
