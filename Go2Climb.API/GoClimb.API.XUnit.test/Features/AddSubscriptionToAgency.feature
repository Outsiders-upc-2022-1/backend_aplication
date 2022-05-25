Feature: AddSubscriptionToAgency
	As an agency I want to change my subscription plan to offer more services to my clients.

	Background: 
		Given the Endpoint https://localhost:5001/api/v1/subscriptions is available
		And A agency already exists
		  | Id | Name        | Email              | PhoneNumber | Description                                             | Location | Ruc         | Photo | Score |
		  | 1  | ClimbWithUs | climbwithus@outlook.com | 999888777   | What are you waiting for? Enjoy a new adventure with us | Cuzco    | 12345678912 | none  | 5     |

	@subscription-adding
	Scenario: Add a new subscription to the agency
		When A new Subscription Request is Sent
		  | name        | description | price |
		  | ClimbWithUs | A new sub!  | 100   |
		Then A response with status 200 is shown