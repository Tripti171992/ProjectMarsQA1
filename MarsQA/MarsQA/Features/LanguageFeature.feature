Feature: LanguageFeature

As a user, I would like to add, delete and update a language, so that 
I can manage languages successfully.

Scenario Outline: Add a language with valid credentials
	Given I logged into the Mars portal successfully
	When I added language '<Language>' and level '<Level>'
	Then A language '<Language>' added success message should be displayed
	And A language '<Language>' and Level '<Level>' record should be added successfully
Examples:
	| Language | Level          |
	| Hindi    | Basic          |
	| English  | Fluent         |
	| Korean   | Basic          |
	| Japanese | Conversational |
Scenario Outline: Update an existing language record with valid credentials
	Given I logged into the Mars portal successfully
	When I update language '<Language>' and level '<Level>' of an existing record
	Then A language '<Language>' updated success message should be displayed
	And A language '<Language>' and level '<Level>' record should be updated successfully
Examples:
	| Language | Level  |
	| Spanish  | Fluent |

Scenario Outline: Delete an exiisting language record with valid credentials
	Given I logged into the Mars portal successfully
	When I delete a language '<Language>'  record
	Then A language '<Language>' deleted success message should be displayed
	And A language '<Language>' record should be deleted
Examples:
	| Language |
	| Hindi    |
