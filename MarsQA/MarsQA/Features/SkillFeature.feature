Feature: SkillFeature

As a user, I would like to add, delete and update a skill, so that 
I can manage skills successfully.

Scenario Outline: Add a skill with valid credentials
	Given I logged into the Mars portal successfully
	When I added '<Skill>' and '<Level>'
	Then A skill '<Skill>' added success message should be displayed
	And A '<Skill>' and '<Level>' record should be added successfully
Examples:
	| Skill  | Level        |
	| Java   | Beginner     |
	| Python | Expert       |
	| C++    | Intermediate |

Scenario Outline: Update a existing skill record with valid credentials
	Given I logged into the Mars portal successfully
	When I update '<Skill>' and '<Level>' of an existing record
	Then A skill '<Skill>' updated success message should be displayed
	And A '<Skill>' and '<Level>' of the existing record should be updated successfully
Examples:
	| Skill | Level  |
	| C#    | Expert |

Scenario: Delete an exiisting skill record with valid credentials
	Given I logged into the Mars portal successfully
	When I delete a skill '<Skill>' record
	Then A skill '<Skill>' deleted success message should be displayed
	And A skill '<Skill>' record should be deleted
Examples:
	| Skill |
	| Java  |


