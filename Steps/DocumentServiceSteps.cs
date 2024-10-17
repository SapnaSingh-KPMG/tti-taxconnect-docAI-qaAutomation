using DocAIPCPAPI.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using UIFramework.Base;

namespace DocAIPCPQAAutomation.Steps
{

    [Binding]
    public class DocumentServiceSteps : BaseStep
    {
        private readonly ParallelConfig _pConfig;
        DocumentServicePage page;

        public DocumentServiceSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _pConfig = parallelConfig;
            page = new DocumentServicePage(parallelConfig);
        }

        [Given(@"I send GET request to the pre-engineered api endpoint with a valid applicationId (.*) and documentId (.*)")]
        public void SendGETRequestToThePreEngineeredApiEndpointWithAValidApplicationIdAndDocumentId(string applicationId, string documentId)
        {
            page.SendGETRequestWithApplicationIdAndDocumentId(applicationId, documentId);
        }



    }
}