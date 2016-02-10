using System.Linq;
using FluentAssertions;
using Simple.Data;
using TicketSales.Purchasing.Data.Specifications;
using Xunit;

namespace TicketSales.Tests.Purchasing
{
    public class TicketsByEventIdSpecificationTests
    {
        [Theory, TestData]
        public void Execute_Returns_Correct_Result(
            TicketsByEventIdSpecification sut)
        {
            var db = Database.Open();
            db.Tickets.Insert(TestData.AllTickets);
            var expected = TestData.AllTickets.Take(TestData.HalfNumberOfTickets).ToList();
            var actual = sut.Execute(TestData.EventId);
            actual.ShouldAllBeEquivalentTo(expected);
        }
    }
}