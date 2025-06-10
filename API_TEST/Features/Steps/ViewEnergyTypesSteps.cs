using System.Net;
using NUnit.Framework;
using RestSharp;
using Screenplay.Actors;
using Screenplay.Tasks;
using TechTalk.SpecFlow;

namespace Features.Steps
{
    [Binding]
    public class ViewEnergyTypesSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Stage _stage;

        public ViewEnergyTypesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _stage = _scenarioContext.Get<Stage>("Stage");
        }

        [When(@"I request the list of energy types")]
        public void WhenIRequestTheListOfEnergyTypes()
        {
            _stage.User.AttemptsTo(ViewEnergyTypes.Execute());
        }

        [Then(@"the system returns all available energy types with IDs")]
        public void ThenTheSystemReturnsAllAvailableEnergyTypesWithIDs()
        {
            var response = _stage.User.Recall<RestResponse>("response");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content,
                Does.Contain("energy_id")
                    .And.Contain("price_per_unit")
                    .And.Contain("quantity_of_units")
                    .And.Contain("unit_type"));
        }
    }
}