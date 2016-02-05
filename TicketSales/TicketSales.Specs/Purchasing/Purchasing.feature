Feature: Purchasing
	In order to go to events I'm interested in
	As a Customer
	I want to buy tickets

Background: 
	Given there are 4 tickets left for event 42
	And I am on the Buy Ticket Page

@Purchasing
Scenario: Purchase Ticket
	And I have chosen 3 tickets
	When I press buy
	Then the order should be put through
	And there should be 1 tickets left
	And I should be redirected to the confirmation page
	And on the confirmation page I should see a message saying 'Thanks!!'
	And I should be sent an email confirmation

Scenario: Not enough inventory
	And I have chosen 6 tickets
	When I press buy
	Then there should be 4 tickets left
	And I should be redirected to the cantfirmation page

Scenario: Error
	And purchasing is broken
	When I press buy
	And I should see a message saying 'oops, something went wrong'

