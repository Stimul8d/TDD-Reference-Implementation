using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Ploeh.AutoFixture.Xunit2;
using Simple.Data;
using TicketSales.Events.Domain;
using TicketSales.Infrastructure.Data;
using TicketSales.Purchasing.Domain;

namespace TicketSales.Tests.Purchasing
{
    public class TestData : AutoDataAttribute
    {
        public const int TicketId = 42;
        public const int NotEventId = 999;
        public const string EventName = "Event Name";
        public const int UserId = 15;
        public const int EventId = 1337;
        public const int HalfNumberOfTickets = 50;
        public const int TotalNumberOfTickets = 100;
        public const int TenLessThanTotalNumberOfTickets = 10;
        public const int TenMoreThanTotalNumberOfTickets = 110;

        private static List<Ticket> allTickets = new List<Ticket>();
        public static IEnumerable<Ticket> AllTickets { get { return allTickets; } }

        public TestData() : base(
            new Fixture().Customize(new AutoNSubstituteCustomization())
            .Customize(new StableFiniteSequenceCustomization()))
        {
            allTickets.Clear();
            allTickets.AddRange(Enumerable.Repeat(new Ticket(Guid.NewGuid(),
                EventId), HalfNumberOfTickets));

            allTickets.AddRange(Enumerable.Repeat(new Ticket(Guid.NewGuid(),
                NotEventId), HalfNumberOfTickets));

            var ticketRepo = Substitute.For<IGetAll<Ticket>>();
            ticketRepo.All().Returns(AllTickets);
            Fixture.Inject(ticketRepo);

            var events = new List<Event> { new Event(EventId, EventName, "Stoke") };
            var eventRepo = Substitute.For<IGetAll<Event>>();
            eventRepo.All().Returns(events);
            Fixture.Inject(eventRepo);

            var orders = new List<Order> { new Order(Guid.NewGuid(), UserId, EventId, 3) };
            var orderRepo = Substitute.For<IGetAll<Order>>();
            orderRepo.All().Returns(orders);
            Fixture.Inject(orderRepo);

            Database.UseMockAdapter(new InMemoryAdapter());

        }
    }
}
