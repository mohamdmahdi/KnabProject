Feature: Test CRUD methods in Trello API tesing

Scenario: Create a new baord
	Given I define the request for the API
	And I set the Post method for the API call
	And I set the board name to <Name>
	And I send the Post request to add new board
	Then I receive a valid HTTP 200 code 
Examples: 
| Name |
| Car Design Board |


Scenario: : Get all boards 
Given I define the request for the API
And I set the Get method for the API call
And I set the Get method to retrieve all boards name, ID and URL
And I send the Get request to get all boards
Then I receive a valid HTTP 200 code


@DeleteBoard
Scenario: Delete the baord 
Given I define Delete request for the API
And I checked if the required <Name> board is exists
And I set the Delete method for the API call
And I send the Delete reques to delete the board
Then I receive a valid HTTP 200 code
Examples:
| Name |
| Car Design Board    |

#comment