using NSubstitute;
using Ploeh.AutoFixture.Xunit2;
using TicketSales.Infrastructure.Data;
using TicketSales.Purchasing.Domain;
using TicketSales.Purchasing.Domain.Events;
using TicketSales.Purchasing.Domain.Handlers;
using Ploeh.AutoFixture.AutoNSubstitute;
using Xunit;

namespace TicketSales.Tests.Purchasing
{
    public class UpdateInventoryHandlerTests
    {
        [Theory, TestData]
        public void Handle_Updates_Inventory_With_Enough_Inventory(TicketsPurchasedUpdateInventoryHandler sut,
            IGetAll<Ticket> ticketGetter, IDelete<Ticket> ticketDeleter)
        {
            ticketDeleter.Received(3).Delete(Arg.Any<Ticket>());

            sut.Handle(new TicketsPurchasedEvent(TestData.UserId,
                TestData.TicketId, TestData.TenLessThanTotalNumberOfTickets));


            //sut.Tickets.Count().Should().Be(41);
            //TODO:Fix me
        }
    }
}
