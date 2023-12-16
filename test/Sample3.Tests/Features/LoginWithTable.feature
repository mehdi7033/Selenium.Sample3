Feature: LoginWithTable

A short summary of the feature

@tag1
Scenario: Login with data arranged in table.
	Given I am at the home page of web application.
	When I enter the credentials.
	| Key      | Value                |
	| Username | automation@gmail.com |
	| Password | 54321                |
	And I click the login button.
	#Then I successfully logged in.
