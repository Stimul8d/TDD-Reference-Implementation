using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using TechTalk.SpecFlow;
using TicketSales.Events.Domain;
using TicketSales.Events.Queries;
using TicketSales.Web.Controllers;
using TicketSales.Web.ViewModels.Search;

namespace TicketSales.Specs.Events
{
    [Binding]
    public class EventSearchSteps
    {
        private EventsController controller;
        private ActionResult result;
        private Event testEvent;

        [Given(@"I have an event called '(.*)' in '(.*)'")]
        public void GivenIHaveAnEventCalledIn(string name, string location)
        {
            testEvent = new Event(name, location);
        }

        [Given(@"I am on the search events page")]
        public void GivenIAmOnTheSearchEventsPage()
        {
            var events = new List<Event> {testEvent};
            controller = new EventsController(new EventsSearch(events));
        }

        [Given(@"the search is broken")]
        public void GivenTheSearchIsBroken()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I search for (.*)")]
        public void WhenISearchFor(string term)
        {
            result = controller.Search(new SearchRequestViewModel { Term = term });
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
            //TODO: THIS NEXT
        }

        [Then(@"the results should show a message saying '(.*)'")]
        public void ThenTheResultsShouldShowAMessageSaying(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
