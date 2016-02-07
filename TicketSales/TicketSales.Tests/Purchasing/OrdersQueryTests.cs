using System.Linq;
using FluentAssertions;
using TicketSales.Purchasing.Queries;
using Xunit;

namespace TicketSales.Tests.Purchasing
{
    public class OrdersQueryTests
    {
        [Theory, TestData]
        public void Execute_Returns_Correct_Result(OrdersQuery sut)
        {
            var result = sut.Execute();
            result.Count().Should().BeGreaterThan(0);//avoid vacuous truth
            result.All(o => o.EventId == TestData.EventId).Should().BeTrue();
        }
    }
}
