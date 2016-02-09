using System.Linq;
using FluentAssertions;
using TicketSales.Purchasing.Queries;
using Xunit;

namespace TicketSales.Tests.Purchasing
{
    public class AvailableTicketsQueryTests
    {
        [Theory, TestData]
        public void Execute_Returns_Correct_Result(AvailableTicketsQuery sut)
        {
            var result = sut.Execute(TestData.TicketId);
            result.All(t => t.EventId == TestData.TicketId).Should().BeTrue();
        }
    }
}