Feature: Purchasing
	In order to go to events I'm interested in
	As a Customer
	I want to buy tickets

@Purchasing
Scenario: Purchase Ticket
	Given I have selected an event
	And I have chosen the number of tickets i want
	And there is enough tickets left
	When I press buy
	Then the order should be put through
	And I should see a message saying thankyou
	And I should receive an email confirming the details

Scenario: Not enough inventory
	Given I have selected an event
	And I have chosen the number of tickets i want
	And there is not enough tickets left
	When I press buy
	And I should see a message saying 'hard luck loser'

Scenario: Error
	Given I have selected an event
	And I have chosen the number of tickets i want
	And the purchasing service is broken
	When I press buy
	And I should see a message saying 'oops, something went wrong'

