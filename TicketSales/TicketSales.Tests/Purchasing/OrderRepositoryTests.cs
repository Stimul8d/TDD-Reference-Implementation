using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Simple.Data;
using TicketSales.Purchasing.Data;
using TicketSales.Purchasing.Domain;
using Xunit;

namespace TicketSales.Tests.Purchasing
{
    public class OrderRepositoryTests
    {
        [Theory, TestData]
        public void All_Returns_Correct_Result(
            OrderRepository sut, IEnumerable<Order> data)
        {
            Database.Open().Orders.Insert(data);

            var result = sut.All();
            result.ShouldAllBeEquivalentTo(data);
        }

        [Theory, TestData]
        public void Create_Adds_Order(OrderRepository sut, Order data)
        {
            var db = Database.Open();
            var beforeCount = db.Orders.GetCount();

            sut.Create(data);

            var afterCount = (int)db.Orders.GetCount();
            afterCount.Should().Be(beforeCount + 1);
        }
    }
}
