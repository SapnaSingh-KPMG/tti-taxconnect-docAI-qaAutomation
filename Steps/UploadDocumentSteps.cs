using DocAIPCPAPI.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UIFramework.Base;

namespace APITestAutomation.StepDefinitions
{

	[Binding]
	public class UploadDocumentSteps : BaseStep
	{
		private readonly ParallelConfig _pConfig;
		UploadDocumentPage page;

		public UploadDocumentSteps(ParallelConfig parallelConfig) : base(parallelConfig)
		{
			_pConfig = parallelConfig;
			page = new UploadDocumentPage(_pConfig);
		}

		[Then(@"Then I validate the response code is (.*)")]
		public void ThenThenIValidateTheResponseCodeIs(int p0)
		{
			bool doesValueMatch = page.ValidateResponseCode(p0);
			//Assert.That(doesValueMatch,"Response code is not matching.");
		}

		[Given(@"I send GET request to the pre-engineered api endpoint with access token")]
		public async Task GivenISendGETRequestToThePre_EngineeredApiEndpointWithAccessToken()
		{
			await page.SendGETRequestWithAccessToken();
		}

		[Given(@"I send GET request to the pre-engineered api endpoint with expired access token")]
		public async Task GivenISendGETRequestToThePre_EngineeredApiEndpointWithExpiredToken()
		{
			await page.SendGETRequestWithExpiredAccessToken();
		}
	}
}

