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
            IGetAll<Ticket> ticketGetter, IDelete<Ticket> ticketDeleter,
            ICreate<Order> orderCreator)
        {
            sut.Handle(new TicketsPurchasedEvent(TestData.TicketId,
                TestData.EventId, TestData.TenLessThanTotalNumberOfTickets));

            ticketGetter.Received(1).All();
            ticketDeleter.Received(10).Delete(Arg.Any<Ticket>());
            orderCreator.Received(1).Create(Arg.Any<Order>());
        }

        [Theory, TestData]
        public void Handle_Is_NOP_Without_Enough_Inventory(TicketsPurchasedUpdateInventoryHandler sut,
            IGetAll<Ticket> ticketGetter, IDelete<Ticket> ticketDeleter,
            ICreate<Order> orderCreator)
        {
            sut.Handle(new TicketsPurchasedEvent(TestData.TicketId,
                TestData.EventId, TestData.TenMoreThanTotalNumberOfTickets));

            ticketGetter.Received(1).All();
            ticketDeleter.DidNotReceive().Delete(Arg.Any<Ticket>());
            orderCreator.DidNotReceive().Create(Arg.Any<Order>());
        }
    }
}
