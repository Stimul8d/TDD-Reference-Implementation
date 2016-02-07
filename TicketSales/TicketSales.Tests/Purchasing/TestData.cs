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
        public const string EventName = "Event Name";
        public const int UserId = 10;

        public TestData() : base(new Fixture().Customize(new AutoNSubstituteCustomization()))
        {
            var tickets = new List<Ticket>(
                Enumerable.Repeat(new Ticket(Guid.NewGuid(), TicketId), 42));
            var ticketRepo = Substitute.For<IGetAll<Ticket>>();
            ticketRepo.All().Returns(tickets);
            Fixture.Inject(ticketRepo);

            var events = new List<Event> {new Event(EventName, "Stoke")};
            var eventRepo = Substitute.For<IGetAll<Event>>();
            eventRepo.All().Returns(events);
            Fixture.Inject(eventRepo);

            Database.UseMockAdapter(new InMemoryAdapter());

        }
    }
}
