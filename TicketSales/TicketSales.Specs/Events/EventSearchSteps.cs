using System;
using TechTalk.SpecFlow;

namespace TicketSales.Specs.Events
{
    [Binding]
    public class EventSearchSteps
    {    
        [Given(@"I have an event called (.*)")]
        public void GivenIHaveAnEventCalled(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the event is in (.*)")]
        public void GivenTheEventIsIn(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have no events")]
        public void GivenIHaveNoEvents()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the search service is broken")]
        public void GivenTheSearchServiceIsBroken()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I search for (.*)")]
        public void WhenISearchFor(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the results should show an event called (.*)")]
        public void ThenTheResultsShouldShowAnEventCalled(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the results should show a message saying '(.*)'")]
        public void ThenTheResultsShouldShowAMessageSaying(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
