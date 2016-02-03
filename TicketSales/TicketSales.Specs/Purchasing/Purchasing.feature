Feature: Purchasing
	In order to go to events I'm interested in
	As a Customer
	I want to buy tickets

Background: 
	Given there are 3 tickets left for event 42
	And I am on the Buy Ticket Page

@Purchasing
Scenario: Purchase Ticket
	And I have chosen 3 tickets
	When I press buy
	Then the order should be put through
	And there should be 0 tickets left
	And I should see a message saying thankyou
	And I should receive an email confirming the details

Scenario: Not enough inventory
	And I have chosen 6 tickets
	When I press buy
	Then inventory should not be updated
	And I should see a message saying 'hard luck loser'

Scenario: Error
	And purchasing is broken
	When I press buy
	And I should see a message saying 'oops, something went wrong'

