using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using TechTalk.SpecFlow;
using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Purchasing.Domain;
using TicketSales.Purchasing.Domain.Events;
using TicketSales.Purchasing.Queries;
using TicketSales.Web.Controllers;
using TicketSales.Web.ViewModels;
using TicketSales.Web.ViewModels.BuyTickets;

namespace TicketSales.Specs.Purchasing
{
    [Binding]
    public class PurchasingSteps
    {
        private BuyTicketsController controller;
        private IEnumerable<Ticket> tickets;
        private int ticketsInBasket;
        private int eventId;
        private ActionResult result;
        private bool ticketsPurchased;
        private int ticketsLeft;

        public PurchasingSteps()
        {
            DomainEvents.Register<TicketsPurchasedEvent>(e =>
            {
                ticketsPurchased = true;
                ticketsLeft = e.NumberOfTickets;
                if (ticketsLeft < 0) ticketsLeft = 0;
            });
        }

        [Given(@"there are (.*) tickets left for event (.*)")]
        public void GivenThereAreTicketsLeftForEvent(int numOfTickets, int eventId)
        {
            this.eventId = eventId;
            this.ticketsLeft = numOfTickets;
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
            ticketsPurchased.Should().BeTrue();
        }

        [Then(@"there should be (.*) tickets left")]
        public void ThenThereShouldBeTicketsLeft(int expectedNumberOfTicketsLeft)
        {
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
