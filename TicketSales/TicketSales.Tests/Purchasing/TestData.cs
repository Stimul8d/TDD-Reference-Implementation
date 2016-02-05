using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Ploeh.AutoFixture.Xunit2;
using TicketSales.Infrastructure.Data;
using TicketSales.Purchasing.Domain;

namespace TicketSales.Tests.Purchasing
{
    public class TestData : AutoDataAttribute
    {
        public const int TicketId = 42;

        public TestData() : base(new Fixture().Customize(new AutoNSubstituteCustomization()))
        {
            var tickets = new List<Ticket>(Enumerable.Repeat(new Ticket(TicketId), 42));

            var ticketRepo = Substitute.For<IRepository<Ticket>>();
            ticketRepo.All().Returns(tickets);

            Fixture.Inject<IRepository<Ticket>>(ticketRepo);


        }
    }
}
