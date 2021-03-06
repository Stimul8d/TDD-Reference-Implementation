﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using NSubstitute;
using TechTalk.SpecFlow;
using TicketSales.Infrastructure.Data;
using TicketSales.Infrastructure.DomainEvents;
using TicketSales.Purchasing.Domain;
using TicketSales.Purchasing.Domain.Events;
using TicketSales.Purchasing.Domain.Handlers;
using TicketSales.Web.Controllers;
using TicketSales.Web.ViewModels;
using TicketSales.Web.ViewModels.BuyTickets;

namespace TicketSales.Specs.Purchasing
{
    [Binding]
    public class PurchasingSteps : IntegrationTestBase
    {
        private BuyTicketsController controller;
        private int ticketsInBasket;
        private int eventId;
        private ActionResult result;
        private IEnumerable<IHandle<TicketsPurchasedEvent>> ticketsPurchasedHandlers;
        private int userId;

        public PurchasingSteps()
        {
            ticketsPurchasedHandlers = Container.GetAllInstances<IHandle<TicketsPurchasedEvent>>();
        }

        [Given(@"there are (.*) tickets left for event (.*)")]
        public void GivenThereAreTicketsLeftForEvent(int numOfTickets, int eventId)
        {
            this.eventId = eventId;

            for (var i = 0; i < numOfTickets; i++)
            {
                Db.Tickets.Insert(Id: Guid.NewGuid(), EventId: eventId);
            }
        }

        [Given(@"my userid is (.*)")]
        public void GivenMyUseridIs(int userId)
        {
            this.userId = userId;
        }


        [Given(@"I am on the Buy Ticket Page")]
        public void GivenIAmOnTheBuyTicketPage()
        {
            controller = Container.GetInstance<BuyTicketsController>();
        }

        [Given(@"I have chosen (.*) tickets")]
        public void GivenIHaveChosenTickets(int numOfTickets)
        {
            ticketsInBasket = numOfTickets;
        }

        [When(@"I press buy")]
        public void WhenIPressBuy()
        {
            var request = new BuyTicketsRequestViewModel
            {
                UserId = userId,
                EventId = eventId,
                NumberOfTicketsRequired = ticketsInBasket
            };

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
            var repository = Container.GetInstance<IGetAll<Ticket>>();
            repository.All().Count().Should().Be(expectedNumberOfTicketsLeft);
        }

        [Then(@"I should be redirected to the confirmation page")]
        public void ThenIShouldBeRedirectedToTheConfirmationPage()
        {
            (result as RedirectToRouteResult).RouteValues["action"].Should().Be("Confirmation");
        }

        [Then(@"I should be redirected to the cantfirmation page")]
        public void ThenIShouldBeRedirectedToTheCantfirmationPage()
        {
            (result as RedirectToRouteResult).RouteValues["action"].Should().Be("Cantformation");
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
            ticketsPurchasedHandlers
                .Any(h => h is TicketsPurchasedEmailConfirmationHandler)
                .Should().BeTrue();
        }

        [Given(@"purchasing is broken")]
        public void GivenPurchasingIsBroken()
        {
            var boxOffice = Substitute.For<IBoxOffice>();
            boxOffice.When(b => b.SellTickets(Arg.Any<int>(),
                Arg.Any<int>(), Arg.Any<int>()))
                .Do(x => { throw new Exception(); });

            Container.EjectAllInstancesOf<IBoxOffice>();
            Container.Inject(typeof(IBoxOffice), boxOffice);

            controller = Container.GetInstance<BuyTicketsController>();
        }

        [Then(@"I should be redirected to the error page")]
        public void ThenIShouldBeRedirectedToTheErrorPage()
        {
            (result as RedirectToRouteResult).RouteValues["action"].Should().Be("Error");
        }


    }
}
