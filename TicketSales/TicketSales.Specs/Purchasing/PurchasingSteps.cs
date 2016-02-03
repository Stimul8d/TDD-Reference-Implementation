using System;
using TechTalk.SpecFlow;

namespace TicketSales.Specs.Purchasing
{
    [Binding]
    public class PurchasingSteps
    {
        [Given(@"I have selected an event")]
        public void GivenIHaveSelectedAnEvent()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have chosen the number of tickets i want")]
        public void GivenIHaveChosenTheNumberOfTicketsIWant()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"there is enough tickets left")]
        public void GivenThereIsEnoughTicketsLeft()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"there is not enough tickets left")]
        public void GivenThereIsNotEnoughTicketsLeft()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the purchasing service is broken")]
        public void GivenThePurchasingServiceIsBroken()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press buy")]
        public void WhenIPressBuy()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I should see a message saying '(.*)'")]
        public void WhenIShouldSeeAMessageSaying(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the order should be put through")]
        public void ThenTheOrderShouldBePutThrough()
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
    }
}
