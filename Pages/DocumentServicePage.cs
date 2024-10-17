using APIFramework.APIHelpers;
using APITestAutomation.Support;
using Azure.Core;
using Azure.Identity;
using DocAIPCPQAAutomation.Support;
using UIFramework.Base;

namespace DocAIPCPAPI.Pages
{
    public class DocumentServicePage : BasePage
    {
        private readonly ParallelConfig _pConfig;
        public InputDataModel datamodelforGETrequest { get; set; }
        Utilities util;

        public DocumentServicePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _pConfig = parallelConfig;
            util = new Utilities();
        }

        /// <summary>
        /// Sends a GET request with the specified application ID and document ID.
        /// </summary>
        /// <param name="applicationId">The application ID.</param>
        /// <param name="documentId">The document ID.</param>
        /// <returns></returns>
        public async Task SendGETRequestWithApplicationIdAndDocumentId(string applicationId, string documentId)
        {
            var credential = new AzureCliCredential();
            var tokenRequestContext = new TokenRequestContext(new[] { "https://management.azure.com/.default" });
            var accessToken = await credential.GetTokenAsync(tokenRequestContext);

            datamodelforGETrequest = new InputDataModel();
            datamodelforGETrequest.TestDataFolder = util.GetPathOfTestDataFolder();
            datamodelforGETrequest.ScenarioName = "DocumentPromptAnswerGET";
            datamodelforGETrequest.AccessToken = accessToken.ToString();
            datamodelforGETrequest.RequestUrl = Constants.DOCS_PROMPTS_ANSWERS_TEST;

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
