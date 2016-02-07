using TicketSales.Purchasing.Domain.Handlers;
using Xunit;

namespace TicketSales.Tests.Purchasing
{
    public class UpdateInventoryHandlerTests
    {
        [Theory, TestData]
        public void Handle_Updates_Inventory(TicketsPurchasedUpdateInventoryHandler sut)
        {
            //sut.Handle(new TicketsPurchasedEvent(TestData.TicketId, 1));
            //sut.Tickets.Count().Should().Be(41);
            //TODO: FIX THIS
        }
    }
}
