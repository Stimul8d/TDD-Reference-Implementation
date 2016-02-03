Feature: EventSearch
	In order to find events I'm interested in
	As a visitor
	I want to search for events by name and location

Background: 
	Given I have an event called 'Party In The Park' in 'Stoke'
	And I am on the search events page

@Search
Scenario: Search By Location
	Given I am on the search events page
	When I search for Stoke
	Then the results should show an event in Stoke

Scenario: No Results
	Given I am on the search events page
	When I search for NoEventHere
	Then I should see a message saying 'no results'

Scenario: Error
	Given the search is broken
	When I search for Anything
	Then the results should show a message saying 'a problem occurred, try again'
