using System.Net;
using NUnit.Framework;
using RestSharp;
using Screenplay.Actors;
using Screenplay.Tasks;
using TechTalk.SpecFlow;

namespace Features.Steps
{
    [Binding]
    public class PurchaseEnergyUnitsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Stage _stage;

        public PurchaseEnergyUnitsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _stage = _scenarioContext.Get<Stage>("Stage");
        }

        [When(@"I place an order to purchase (.*) units of energy type (.*)")]
        public void WhenIPlaceAnOrderToPurchaseUnitsOfEnergyType(string quantity, string energyId)
        {
            // Store for later assertions if needed
            _stage.User.Remember("energyId", energyId);
            _stage.User.Remember("quantity", quantity);

            _stage.User.AttemptsTo(PurchaseEnergyUnits.With(energyId, quantity));
        }

        [Then(@"the order is successfully placed and confirmed")]
        public void ThenTheOrderIsSuccessfullyPlacedAndConfirmed()
        {
            var response = _stage.User.Recall<RestResponse>("response");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created).Or.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Does.Contain("Your order Id").Or.Contain("You have purchased").IgnoreCase);
        }

        [Then(@"the request is rejected with a 400 Bad Request response")]
        public void ThenTheRequestIsRejectedWithA400BadRequestResponse()
        {
            var response = _stage.User.Recall<RestResponse>("response");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Then(@"the request is rejected with a 404 Not Found response")]
        public void ThenTheRequestIsRejectedWithA404NotFoundResponse()
        {
            var response = _stage.User.Recall<RestResponse>("response");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Then(@"the request is rejected with a 404 Not Found or a 400 Bad Request response")]
        public void ThenTheRequestIsRejectedWithA404NotFoundoR400BadResponse()
        {
            var response = _stage.User.Recall<RestResponse>("response");
            Assert.That(response.StatusCode, Is.AnyOf(HttpStatusCode.NotFound, HttpStatusCode.BadRequest));
        }
    }
}