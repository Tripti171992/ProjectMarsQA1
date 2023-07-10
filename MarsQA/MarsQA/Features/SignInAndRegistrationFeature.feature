Feature: SignInAndRegistrationFeature

As a user, I would like to register and sign in into Mars, so that 
I can manage my Mars account.

Scenario: Sign in to Mars with valid credentials
	Given I logged into the Mars portal successfully
	Then A user should be taken to home page successfully

Scenario: Register to Mars with valid credentials
	Given I registered into the Mars portal
	Then A user should be registered successfully
