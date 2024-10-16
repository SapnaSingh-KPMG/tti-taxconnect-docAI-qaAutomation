Feature: DocumentAI Extract data from the document


Scenario:Validate that pre-engineered api endpoint used to upload document is able to perform GET operation.
	Given I send GET request to the pre-engineered api endpoint with access token
	Then Then I validate the response code is <ResponseCode>
Examples:
	| ResponseCode |
	| 200          | 


Scenario: Verify that the API correctly retrieves prompts when provided with valid applicationId and documentId.
    When I send a GET request to valid "<Endpoint>"
    Then I verify the response status code should be "<Status Code>"
    And I verify the response should contain the extracted prompts in correct format
    Examples:
        | Status Code | Endpoint                                                           |
        | "200"       | "/application/{applicationId}/document/{documentId}/promptanswers" |