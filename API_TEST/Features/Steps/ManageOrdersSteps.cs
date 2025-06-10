using System.Net;
using NUnit.Framework;
using RestSharp;
using Screenplay.Actors;
using Screenplay.Tasks;
using Screenplay.Questions;
using TechTalk.SpecFlow;

namespace Features.Steps
{
    [Binding]
    public class ManageOrdersSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Stage _stage;

        public ManageOrdersSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _stage = _scenarioContext.Get<Stage>("Stage");
        }
        
        [When(@"I request to view my orders")]
        public void WhenIRequestToViewMyOrders()
        {
            _stage.User.AttemptsTo(ViewOrders.Execute());
        }

        [Then(@"the system returns my order history")]
        public void ThenTheSystemReturnsMyOrderHistory()
        {
            Assert.That(_stage.User.AsksFor(OrderHistoryReturned.Exists()), Is.True);
        }

        [Given(@"I have a valid order ID")]
        public void GivenIHaveAValidOrderID()
        {
            // In a real test, you would retrieve this from a previous response or fixture
            _stage.User.Remember("orderId", "abc123");
        }

        [When(@"I request to delete the order")]
        public void WhenIRequestToDeleteTheOrder()
        {
            _stage.User.AttemptsTo(DeleteOrder.WithRememberedId());
        }

        [Then(@"the system confirms the deletion")]
        public void ThenTheSystemConfirmsTheDeletion()
        {
            Assert.That(_stage.User.AsksFor(OrderHistoryReturned.Deleted()), Is.True);
        }

        [Given(@"I provide valid order data in the body")]
        public void GivenIProvideValidOrderDataInTheBody()
        {
            // Example: store update data in memory for use in the update task
            _stage.User.Remember("orderId", "abc123");
            _stage.User.Remember("updatePayload", new { status = "updated" });
        }

        [When(@"I send a PUT request to /ENSEK/orders/abc123")]
        public void WhenISendAPUTRequestToENSEKOrdersAbc123()
        {
            var orderId = _stage.User.Recall<string>("orderId");
            var payload = _stage.User.Recall<object>("updatePayload");
            _stage.User.AttemptsTo(UpdateOrder.With(orderId, payload));
        }

        [Then(@"I should receive a 200 response confirming the update")]
        public void ThenIShouldReceiveA200ResponseConfirmingTheUpdate()
        {
            var response = _stage.User.Recall<RestResponse>("response");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}