using System;
using System.Linq;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using TicketSales.Events.Domain;
using TicketSales.Events.Queries;
using Xunit;

namespace TicketSales.Tests.Events
{
    public class EventsSearchTests
    {
        [Theory, AutoData]
        public void Execute_Returns_Correct_Result(EventsSearch sut, string searchTerm)
        {
            var result = sut.Execute(searchTerm);
            Func<Event, bool> containsSearchTerm = e => e.Location == searchTerm || e.Name == searchTerm;

            result.All(containsSearchTerm).Should().BeTrue();
        }
    }
}
