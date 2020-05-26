Feature: login
	In order to login to Trello Page

@mytag
Scenario: Login
	Given I go to the website 
	And I enter the the <username> 
	And In the atlassian page I enter the the <password> 
	Then I got the Board home page
	Examples: 
	| username |password|
	| tests.workout.user@gmail.com | Testuser!01 |  


