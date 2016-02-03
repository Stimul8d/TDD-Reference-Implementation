using System.Collections.Generic;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Ploeh.AutoFixture.Xunit2;
using TicketSales.Purchasing.Domain;

namespace TicketSales.Tests.Purchasing
{
    public class TestData : AutoDataAttribute
    {
        public const int TicketId = 42;

        public TestData() : base(new Fixture().Customize(new AutoNSubstituteCustomization()))
        {
            var tickets = new List<Ticket> {new Ticket(TicketId)};
            Fixture.Inject<IEnumerable<Ticket>>(tickets);
        }
    }
}
