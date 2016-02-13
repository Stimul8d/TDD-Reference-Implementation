using System;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using NSubstitute;
using TechTalk.SpecFlow;
using TicketSales.Events.Domain;
using TicketSales.Infrastructure;
using TicketSales.Web.Controllers;
using TicketSales.Web.ViewModels.Search;

namespace TicketSales.Specs.Events
{
    [Binding]
    public class EventSearchSteps : IntegrationTestBase
    {
        private EventsController controller;
        private ActionResult result;

        [Given(@"I have an event called '(.*)' in '(.*)'")]
        public void GivenIHaveAnEventCalledIn(string name, string location)
        {
            Db.Events.Insert(Id: 1, Name: name, Location: location);
        }

        [Given(@"I am on the search events page")]
        public void GivenIAmOnTheSearchEventsPage()
        {
            controller = Container.GetInstance<EventsController>();
        }

        [Given(@"the search is broken")]
        public void GivenTheSearchIsBroken()
        {
            var search = Substitute.For<IQuery<string, Event>>();
            search.Execute().ReturnsForAnyArgs(x => { throw new Exception(); });
            controller = new EventsController(search);
        }

        [When(@"I search for (.*)")]
        public void WhenISearchFor(string term)
        {
            result = controller.SearchResults(new SearchRequestViewModel { Term = term });
        }

        [Then(@"the results should show an event in (.*)")]
        public void ThenTheResultsShouldShowAnEventIn(string location)
        {
            var model = result.Model<SearchResponseViewModel>();
            model.Events.Where(e => e.Location == location).Should().NotBeEmpty();
        }

        [Then(@"I should see a message saying '(.*)'")]
        public void ThenIShouldSeeAMessageSaying(string message)
        {
            var model = result.Model<SearchResponseViewModel>();
            model.Message.Should().Be(message);
        }
    }
}
