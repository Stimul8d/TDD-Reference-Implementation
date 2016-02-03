Feature: EventSearch
	In order to find events I'm interested in
	As a visitor
	I want to search for events by name and location

Background: 
	Given I have an event called 'Party In The Park' in 'Stoke'
	And I am on the search events page

@Search
Scenario: Search By Location
	When I search for Stoke
	Then the results should show an event in Stoke

Scenario: No Results
	When I search for SomethingElse
	Then I should see a message saying 'No Results'

Scenario: Error
	Given the search is broken
	When I search for Anything
	Then I should see a message saying 'Oops. Something went wrong!'
