Feature: GmailBDDTests

Scenario: Send email from draft
	Given I am logged in as "emailsendingtestuser@gmail.com" user and "testuserpassword" password
	When I create and save new message draft
	| To                         | Topic        | Message                                                                      |
	| someadresfortest@gmail.com | Test Message | Message Body\r\nMessage Body\r\nMessage Body\r\nMessage Body\r\nMessage Body |
	And I open draft
	And I send message
	Then message should be in sent folder