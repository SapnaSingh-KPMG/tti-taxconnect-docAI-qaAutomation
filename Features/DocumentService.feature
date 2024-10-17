Feature: DocumentService
As a user
I want to retrieve document prompt answers
So that I can view the details of a specific document

Scenario: Successfully retrieve document prompt answers
  Given  I send GET request to the pre-engineered api endpoint with a valid applicationId <applicationId> and documentId <documentId>
  Then  I validate the response code is <ResponseCode>
 

  Examples:
    | applicationId | documentId                           | ResponseCode |
    | PrivateClient | 26f6fd16-4b4b-4b22-9973-e6ab50b42841 |           200|
	
	
Scenario: Fail to retrieve document prompt answers with invalid documentId
  Given  I send GET request to the pre-engineered api endpoint with a valid applicationId "<applicationId> and documentId "<documentId>"
 Then  I validate the response code is <ResponseCode>
  Then I validate the response content should not be null

  Examples:
    | applicationId | documentId                           | ResponseCode |
    | PrivateClient | 26f6fd16-4b4b-4b22-9973-e6ab50b42841 |           401|
