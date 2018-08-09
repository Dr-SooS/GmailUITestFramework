Feature: GmailUserVerification

Background: 
	Given I am logged in as "Test User" user with "emailsendingtestuser@gmail.com" email and "testuserpassword" password

Scenario: Verify user data
	When I open user details
	Then correct user data should be displayed
