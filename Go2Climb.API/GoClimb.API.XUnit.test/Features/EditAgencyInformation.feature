Feature: EditAgencyInformation
	As agency 
	I want to edit my business page 
	So that place all my information and means of contact.

	Background: 
		Given the Endpoint https://localhost:5001/api/v1/agencies/1 is available
		And A agency is already stored
		  |Id |Name      |Email            |PhoneNumber |Description |Location |Ruc      |Photo |Score |
		  |1  |Climbling |Climbling@go.com |987654321   |funny       |calle 2  |12345678 |none  |5     |
	
	
@agency-editing
Scenario: Edit agency information with all required fields
	When A Put Request is sent
	  |Id |Name        |Email            |PhoneNumber |Description |Location      |Ruc      |Photo |Score |
	  |1  |MockUpClimb |Climbling@go.com |924816523   |seriously   |calle 3 nueva |12345678 |none  |5     |
	Then A Response with Status 201 is received

Scenario: Edit agency information with the wrong fields
	When A Put Request is sent
	  |Id |Name        |Email            |PhoneNumber |Description |Location      |Ruc    |Photo |Score |
	  |2  |MockUpClimb |Climbling@go.com |elementor   |seriously   |calle 2 nueva |newruc |none  |5     |
   	Then A Response with status 400 is received