Feature: Feature1

A short summary of the feature
// Swagger url https://fakerestapi.azurewebsites.net/index.html

@tag1
Scenario: Faker Rest Api Get user credetial information
	Given request passed with user id <id>
	Then verify request status 
	And verify user name to be <userName>
	And verify user pwd to be <pwd>
	Examples: 
	| id | userName | pwd |
	| 2   | User 2   | Password2    |
