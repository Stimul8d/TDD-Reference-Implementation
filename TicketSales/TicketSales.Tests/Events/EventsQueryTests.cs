using System;
using System.Linq;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using TicketSales.Events.Domain;
using TicketSales.Events.Queries;
using TicketSales.Tests.Purchasing;
using Xunit;

namespace TicketSales.Tests.Events
{
    public class EventsQueryTests
    {
        [Theory, TestData]
        public void Execute_Returns_Correct_Result(EventsQuery sut)
        {
            var result = sut.Execute(TestData.EventName);
            Func<Event, bool> containsSearchTerm = e => 
                e.Location == TestData.EventName || e.Name == TestData.EventName;

            result.Count().Should().BeGreaterOrEqualTo(1);//avoid vacuous truth
            result.All(containsSearchTerm).Should().BeTrue();
        }
    }
}
