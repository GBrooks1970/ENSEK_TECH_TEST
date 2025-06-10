using System.Net;
using NUnit.Framework;
using RestSharp;
using Screenplay.Actors;
using TechTalk.SpecFlow;

namespace Features.Steps
{
    [Binding]
    public class CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Stage _stage;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _stage = _scenarioContext.ContainsKey("Stage")
                ? _scenarioContext.Get<Stage>("Stage")
                : new Stage(new User("API Tester"));
            _scenarioContext.Set(_stage, "Stage");
        }

        [Given(@"I am not authenticated")]
        public void GivenIAmNotAuthenticated()
        {
            // Do not set credentials or token
            _stage.User.Remember("username", "invalidUser");
            _stage.User.Remember("password", "invalidPassword");
        }

        [Then(@"I am denied access with a 401 Unauthorized response")]
        public void ThenIAmDeniedAccessWithA401UnauthorizedResponse()
        {
            var response = _stage.User.Recall<RestResponse>("response");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }
    }
}