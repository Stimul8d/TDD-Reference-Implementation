using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Purchasing.Domain;
using TicketSales.Purchasing.Domain.Events;
using Xunit;

namespace TicketSales.Tests.Purchasing
{
    public class BoxOfficeTests
    {
        [Theory, AutoData]
        public void Buy_Tickets_Raises_Event(BoxOffice sut,
            int userId,int eventId,int numberOfTickets)
        {
            var called = false;
            DomainEvents.Register<TicketsPurchasedEvent>(e => called = true);
            sut.SellTickets(userId,eventId,numberOfTickets);

            called.Should().BeTrue();
        }
    }
}