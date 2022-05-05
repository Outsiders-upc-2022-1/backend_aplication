using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Go2Climb.API;
using Go2Climb.API.Agencies.Resources;
using Go2Climb.API.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace GoClimb.API.XUnit.test.Steps
{
    [Binding]
    public class EditAgencyInformationStepsDefinition
    {

        private readonly WebApplicationFactory<Startup> _factory;

        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private AgencyResource Agency { get; set; }
        
        public EditAgencyInformationStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/agencies/(.*) is available")]
        public void GivenTheEndpointHttpsLocalhostApiVAgenciesIsAvailable(int port, int version, int id)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/agencies/{id}");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }
        
        [Given(@"A Agency is already stored")]
        public async void GivenAAgencyIsAlreadyStored(Table existingAgencyResource)
        {
            var agencyUri = new Uri("https://localhost:5001/api/v1/agencies");
            var resource = existingAgencyResource.CreateSet<SaveAgencyResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var agencyResponse = Client.PostAsync(agencyUri, content);
            var agencyResponseData = await agencyResponse.Result.Content.ReadAsStringAsync();
            var existingAgency = JsonConvert.DeserializeObject<AgencyResource>(agencyResponseData);
            Agency = existingAgency;

        }

        [When(@"A Put Request is sent")]
        public void WhenAPutRequestIsSent(Table saveAgencyResource)
        {
            var resource = saveAgencyResource.CreateSet<SaveAgencyResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PutAsync(BaseUri, content);
        }

        [Then(@"A Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(actualStatusCode, actualStatusCode);
        }
        
        /* [Then(@"A Agency information is up-to-date")]
         public async void ThenAAgencyInformationIsUpToDate(Table expectedAgencyResource)
         {
             var expectedResource = expectedAgencyResource.CreateSet<AgencyResource>().First();
             var responseData = await Response.Result.Content.ReadAsStringAsync();
             var resource = JsonConvert.DeserializeObject<AgencyResource>(responseData);
             var jsonExpectedResource = expectedAgencyResource.ToJson();
             var jsonActualResource = resource.ToJson();
             Assert.Equal(jsonExpectedResource, jsonActualResource);
         }*/
        
    }
}