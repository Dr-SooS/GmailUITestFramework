Feature: GmailBDDMailSenfingTests

Background: 
	Given I am logged in as "Test User" user with "emailsendingtestuser@gmail.com" email and "testuserpassword" password
	When I create and save new message draft
	| To                         | Topic        | Message                                                                      |
	| someadresfortest@gmail.com | Test Message | Message Body\r\nMessage Body\r\nMessage Body\r\nMessage Body\r\nMessage Body |

Scenario: Send email from draft
	When I open draft
	And I send message
	Then message should be in sent folder

Scenario: Delete email
	When I open draft
	And I send message
	And I delete sent messages
	Then message should be in trash folder