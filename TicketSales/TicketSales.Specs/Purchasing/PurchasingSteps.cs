using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using StructureMap;
using TechTalk.SpecFlow;
using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Purchasing.Domain;
using TicketSales.Purchasing.Domain.Events;
using TicketSales.Purchasing.Domain.Handlers;
using TicketSales.Purchasing.Queries;
using TicketSales.Web.Controllers;
using TicketSales.Web.DependencyResolution;
using TicketSales.Web.ViewModels;
using TicketSales.Web.ViewModels.BuyTickets;

namespace TicketSales.Specs.Purchasing
{
    [Binding]
    public class PurchasingSteps : IntegrationTestBase
    {
        private BuyTicketsController controller;
        private IEnumerable<Ticket> tickets;
        private int ticketsInBasket;
        private int eventId;
        private ActionResult result;
        private int ticketsLeft;
        private IEnumerable<IHandle<TicketsPurchasedEvent>> ticketsPurchasedHandlers;

        public PurchasingSteps()
        {
            //now i need to set up the bindings in defaultregistry to make queries singleton etc...
            ticketsPurchasedHandlers = Container.GetAllInstances<IHandle<TicketsPurchasedEvent>>();
        }

        [Given(@"there are (.*) tickets left for event (.*)")]
        public void GivenThereAreTicketsLeftForEvent(int numOfTickets, int eventId)
        {
            this.eventId = eventId;
            ticketsLeft = numOfTickets;
            tickets = Enumerable.Repeat(new Ticket(eventId), numOfTickets);
        }

        [Given(@"I am on the Buy Ticket Page")]
        public void GivenIAmOnTheBuyTicketPage()
        {
            controller = new BuyTicketsController(new AvailableTicketsQuery(tickets));
        }

        [Given(@"I have chosen (.*) tickets")]
        public void GivenIHaveChosenTickets(int numOfTickets)
        {
            ticketsInBasket = numOfTickets;
        }

        [When(@"I press buy")]
        public void WhenIPressBuy()
        {
            var request = new BuyTicketsRequestViewModel { EventId = eventId, NumberOfTicketsRequired = ticketsInBasket };
            result = controller.Buy(request);
        }

        [Then(@"the order should be put through")]
        public void ThenTheOrderShouldBePutThrough()
        {
            ticketsPurchasedHandlers
                .Any(h => h is TicketsPurchasedUpdateInventoryHandler)
                .Should().BeTrue();
        }

        [Then(@"there should be (.*) tickets left")]
        public void ThenThereShouldBeTicketsLeft(int expectedNumberOfTicketsLeft)
        {
            var handlers = Container.GetAllInstances<IHandle<InventoryUpdatedEvent>>();

            ticketsLeft.Should().Be(expectedNumberOfTicketsLeft);
        }

        [Then(@"I should be redirected to the confirmation page")]
        public void ThenIShouldBeRedirectedToTheConfirmationPage()
        {
            (result as RedirectToRouteResult).RouteValues["action"].Should().Be("Confirmation");
        }

        [Then(@"I should be redirected to the cantfirmation page")]
        public void ThenIShouldBeRedirectedToTheCantfirmationPage()
        {
            (result as RedirectToRouteResult).RouteValues["action"].Should().Be("NotEnoughLeft");
        }

        [Then(@"on the confirmation page I should see a message saying '(.*)'")]
        public void ThenOnTheConfirmationPageIShouldSeeAMessageSaying(string message)
        {
            var confirmationResult = controller.Confirmation();
            confirmationResult.Model<IHaveAMessage>().Message.Should().Be(message);
        }

        [Then(@"I should be sent an email confirmation")]
        public void ThenIShouldBeSentAnEmailConfirmation()
        {
            
        }


        [Given(@"purchasing is broken")]
        public void GivenPurchasingIsBroken()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I should see a message saying '(.*)'")]
        public void WhenIShouldSeeAMessageSaying(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
