using System.Collections.Generic;
using System.Linq;
using TicketSales.Infrastructure;
using TicketSales.Infrastructure.Data;
using TicketSales.Purchasing.Domain;

namespace TicketSales.Purchasing.Queries
{
    public class OrdersQuery : IQuery<int,Order>
    {
        private readonly IGetAll<Order> ordersGetter;

        public OrdersQuery(IGetAll<Order> ordersGetter )
        {
            this.ordersGetter = ordersGetter;
        }

        public IEnumerable<Order> Execute(int userId = 0)
        {
            return ordersGetter.All().Where(o => o.UserId == userId).ToList();
        }
    }
}
