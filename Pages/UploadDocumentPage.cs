using APIFramework.APIHelpers;
using APITestAutomation.Support;
using Azure.Core;
using Azure.Identity;
using DocAIPCPQAAutomation.Support;
using UIFramework.Base;

namespace DocAIPCPAPI.Pages
{
	public class UploadDocumentPage : BasePage
	{
		private readonly ParallelConfig _pConfig;
		public InputDataModel datamodelforGETrequest { get; set; }
		Utilities util;

		public UploadDocumentPage(ParallelConfig parallelConfig) : base(parallelConfig)
		{
			_pConfig = parallelConfig;
			util = new Utilities();
		}

		/// <summary>
		/// Gets response code from Chat Prompt Proxy API
		/// </summary>
		public async Task SendGETRequestWithExpiredAccessToken()
		{
			var expiredAccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ik1jN2wzSXo5M2c3dXdnTmVFbW13X1dZR1BrbyJ9.eyJhdWQiOiI0NjhhNTI0OS1mNjM1LTRhNWEtYjc2MC04OGRjMTY3YTNkNGMiLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vZGVmZjI0YmItMjA4OS00NDAwLThjOGUtZjcxZTY4MDM3OGIyL3YyLjAiLCJpYXQiOjE3Mjc4OTg0ODQsIm5iZiI6MTcyNzg5ODQ4NCwiZXhwIjoxNzI3OTAzNDYwLCJhaW8iOiJBYVFBVy84WUFBQUFLNk8vbzkwQ3F5dlE3VkRTR1l6TkNiRElSQmpHVVljSWptQzN4Y2N1cFVGSDNkd2JNeWNNWHVIRTBwUFNGUnJ1T1dHdW1RVERrK0tHTTJ3YVN3MDhDZXNpdmtQdUFUSCtFQUVuZlBMak43SzNQMktqVWxNVkdpWHhRanYwRnZhWmZZUE8zZVBwZWlJbGdWVWNSUEJEUmVZN0YzdVMrbllXMEExSHNpazYxY1FFNHA0ZU9JWGNSYUl1NWJ5THdrYks0eFU1M09oRW1MNGd1eDNkU09YallBPT0iLCJhenAiOiI0NjhhNTI0OS1mNjM1LTRhNWEtYjc2MC04OGRjMTY3YTNkNGMiLCJhenBhY3IiOiIyIiwiZW1haWwiOiJOaXZlZGl0YS5NZWhyYUBrcG1nLmNvLnVrIiwiZ3JvdXBzIjpbIjY0MmMwODFmLTc3Y2YtNGQ1MS05NTJmLTVkOGE4NzYxYzM5ZSIsIjBiNGU4MmIzLTA3OGEtNDViYy1hZjAzLTg1ZmUwNTQ4ZTUyNyJdLCJuYW1lIjoiTWVocmEsIE5pdmVkaXRhIiwib2lkIjoiNjlmMGNkZTEtNGE3OC00YmFiLTgwZDktY2I0YjAzOTE3YzRiIiwicHJlZmVycmVkX3VzZXJuYW1lIjoiTml2ZWRpdGEuTWVocmFAa3BtZy5jby51ayIsInJoIjoiMC5BUkVBdXlUXzNva2dBRVNNanZjZWFBTjRza2xTaWtZMTlscEt0MkNJM0JaNlBVd1JBTDQuIiwic2NwIjoiQXV0aFJvdXRlci5EZXYgQXV0aFJvdXRlci5UZXN0IEF1dGhSb3V0ZXIuVUFUIiwic3ViIjoiU3p1NTR6ZmRmc2Qta2V5Y05QNjlIOVBUdUNhSXFINkc4SFJBdjllUVhBSSIsInRpZCI6ImRlZmYyNGJiLTIwODktNDQwMC04YzhlLWY3MWU2ODAzNzhiMiIsInV0aSI6Ijdkcnc4ekk4dmtxSlNYaHJXRUkzQUEiLCJ2ZXIiOiIyLjAiLCJvbnByZW1pc2Vzc2FtYWNjb3VudG5hbWUiOiJubWVocmEyIn0.DETXzK7pbFe8soTTWs4UUVp1xa7QUQ5yDA22IThzTymlxBtWr38otlyr0B8ryKt1R76tVu50ENvSf2d2Y_32re7PK85XaSbvntrSKfO10JgHoxSXfhZZGBsEHhKrhAHFMoedOGi9kK0KpHuebwB8gDWAbqmtrP5Q55Tpha7vYlFxcPuzUk0tHE-yfrRnlv2IA7XZTZMyc0GbAEejBOVMjNQbmAzRsE8qAU4da2mLBRMdXS5OSbPjNvMsb_CmuZGEDPJh0bBJKC2lP0_yGq6CuQ9RAcpv35Q9HQZ1_tGSxkzv8YriG8XHnqNCtlXme1c9hcgi18wVf98fk09G2TArfw";
			datamodelforGETrequest = new InputDataModel();
			datamodelforGETrequest.TestDataFolder = util.GetPathOfTestDataFolder();
			datamodelforGETrequest.ScenarioName = "ChatPromptProxyGET";
			datamodelforGETrequest.AccessToken = expiredAccessToken;
			datamodelforGETrequest.RequestUrl = Constants.UPLOAD_DOCS_TEST;

			Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
			requestHeaders.Add("Content-Type", Constants.JSON_HEADER_VALUE);
			requestHeaders.Add("Authorization", $"Bearer {expiredAccessToken}");
			datamodelforGETrequest.RESTRequestHeaders = requestHeaders;

			datamodelforGETrequest.RequestMethod = "GET";

			Initialize init = new Initialize();
			init.InitializeRESTComponents(datamodelforGETrequest);

			RequestExtensions requestExtensions = new RequestExtensions();
			requestExtensions.CreateandExecuteRESTRequest(datamodelforGETrequest);

			var responseFromREST = datamodelforGETrequest.RESTResponse.Content.ToString();
		}

		/// <summary>
		/// Compares expected and acual response status code.
		/// </summary>
		/// <param name="ExpectedResponseCode">received from the feature file</param>
		/// <returns></returns>
		public bool ValidateResponseCode(int ExpectedResponseCode)
		{
			ResponseValidation rValidation = new();
			int actualStatusCode = rValidation.GetResponseStatusCode(datamodelforGETrequest.RESTResponse);
			return actualStatusCode.Equals(ExpectedResponseCode);
		}

		/// <summary>
		/// Calls HTTP GET Method without access token.
		/// </summary>
		/// <returns></returns>
		public async Task SendGETRequestWithAccessToken()
		{
            // Create a DefaultAzureCredential instance
            var credential = new AzureCliCredential();
            var tokenRequestContext = new TokenRequestContext(new[] { "https://management.azure.com/.default" });
            var accessToken = await credential.GetTokenAsync(tokenRequestContext);
            datamodelforGETrequest = new InputDataModel();
			datamodelforGETrequest.TestDataFolder = util.GetPathOfTestDataFolder();
			datamodelforGETrequest.ScenarioName = "UploadDocumentGET";
            datamodelforGETrequest.AccessToken = accessToken.ToString();
			datamodelforGETrequest.RequestUrl = Constants.UPLOAD_DOCS_TEST;

			Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
			requestHeaders.Add("Content-Type", Constants.JSON_HEADER_VALUE);
			requestHeaders.Add("Authorization", $"Bearer {accessToken}");
			datamodelforGETrequest.RESTRequestHeaders = requestHeaders;

			datamodelforGETrequest.RequestMethod = "GET";

			Initialize init = new Initialize();
			init.InitializeRESTComponents(datamodelforGETrequest);

			RequestExtensions requestExtensions = new RequestExtensions();
			requestExtensions.CreateandExecuteRESTRequest(datamodelforGETrequest);

			var responseFromREST = datamodelforGETrequest.RESTResponse.Content.ToString();
		}

	}
}
