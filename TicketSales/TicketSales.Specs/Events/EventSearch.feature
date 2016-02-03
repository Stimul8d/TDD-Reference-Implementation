Feature: EventSearch
	In order to find events I'm interested in
	As a visitor
	I want to search for events by location

@Search
Scenario: Search By Location
	Given I have an event called <name>
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
