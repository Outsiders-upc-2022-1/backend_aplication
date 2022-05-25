using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Go2Climb.API;
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
    public class AddSubscriptionToAgencyStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private AgencyResource Agency { get; set; }

        public AddSubscriptionToAgencyStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/subscriptions is available")]
        public void GivenTheEndpointHttpsLocalhostApiVSubscriptionsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/posts");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [Given(@"A agency already exists")]
        public async void GivenAAgencyAlreadyExists(Table existingAgencyResource)
        {
            var agencyUri = new Uri("https://localhost:5001/api/v1/agencies");
            var resource = existingAgencyResource.CreateSet<SaveAgencyResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var agencyResponse = Client.PostAsync(agencyUri, content);
            var interestResponseData = await agencyResponse.Result.Content.ReadAsStringAsync();
            var existingInterest = JsonConvert.DeserializeObject<AgencyResource>(interestResponseData);
            Agency = existingInterest;
        }

        [When(@"A new Subscription Request is Sent")]
        public void WhenANewSubscriptionRequestIsSent(Table saveSubscriptionResource)
        {
            var resource = saveSubscriptionResource.CreateSet<SaveSubscriptionResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A response with status (.*) is shown")]
        public void ThenAResponseWithStatusIsShown(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(actualStatusCode, actualStatusCode);
        }
    }
}