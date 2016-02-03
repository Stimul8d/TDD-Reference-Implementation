using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;
using TicketSales.Purchasing.Domain;
using TicketSales.Purchasing.Queries;
using TicketSales.Web.Controllers;
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

        [Given(@"there are (.*) tickets left for event (.*)")]
        public void GivenThereAreTicketsLeftForEvent(int numOfTickets, int eventId)
        {
            this.eventId = eventId;
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
            var request = new BuyTicketsRequestViewModel {EventId = eventId, NumberOfTicketsRequired = ticketsInBasket};
            result = controller.Buy(request);
        }

        [Then(@"the order should be put through")]
        public void ThenTheOrderShouldBePutThrough()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"there should be (.*) tickets left")]
        public void ThenThereShouldBeTicketsLeft(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see a message saying thankyou")]
        public void ThenIShouldSeeAMessageSayingThankyou()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should receive an email confirming the details")]
        public void ThenIShouldReceiveAnEmailConfirmingTheDetails()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"inventory should not be updated")]
        public void ThenInventoryShouldNotBeUpdated()
        {
            ScenarioContext.Current.Pending();
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
