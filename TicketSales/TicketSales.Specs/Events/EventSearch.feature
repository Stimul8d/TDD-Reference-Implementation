Feature: EventSearch
	In order to find events I'm interested in
	As a visitor
	I want to search for events by name and location

@Search
Scenario: Search By Location
	Given I have an event called <name>
	And the event is in <location>
	When I search for <location>
	Then the results should show an event called <name>

Scenario: Search By Name
	Given I have an event called <name>
	When I search for <name>
	Then the results should show an event called <name>

Scenario: No Results
	Given I have no events
	When I search for <name>
	Then the results should show a message saying 'no results'

Scenario: Error
	Given the search service is broken
	When I search for <name>
	Then the results should show a message saying 'a problem occurred, try again'
