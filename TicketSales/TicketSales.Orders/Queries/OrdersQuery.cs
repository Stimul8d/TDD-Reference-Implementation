using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Infrastructure;
using TicketSales.Infrastructure.Data;
using TicketSales.Orders.Domain;

namespace TicketSales.Orders.Queries
{
    public class OrdersQuery : IQuery<int,Order>
    {
        private readonly IRepository<Order> ordersRepo;

        public OrdersQuery(IRepository<Order> ordersRepo )
        {
            this.ordersRepo = ordersRepo;
        }

        public IEnumerable<Order> Execute(int userId = 0)
        {
            return ordersRepo.All().Where(o => o.UserId == userId).ToList();
        }
    }
}
