using System.Net;
using NUnit.Framework;
using RestSharp;
using Screenplay.Actors;
using Screenplay.Tasks;
using TechTalk.SpecFlow;

namespace Features.Steps
{
    [Binding]
    public class UserAuthenticationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Stage _stage;

        public UserAuthenticationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _stage = _scenarioContext.Get<Stage>("Stage");
        }

        [Given(@"I have valid credentials")]
        public void GivenIHaveValidCredentials()
        {
            _stage.User.Remember("username", "test");
            _stage.User.Remember("password", "testing");
        }

        [Given(@"I have invalid credentials")]
        public void GivenIHaveInvalidCredentials()
        {
            _stage.User.Remember("username", "invalidUser");
            _stage.User.Remember("password", "invalidPassword");
        }

        [When(@"I attempt to log in")]
        public void WhenIAttemptToLogIn()
        {
            _stage.User.AttemptsTo(Login.WithRememberedCredentials());
        }

        [Then(@"I am successfully authenticated with a bearer token")]
        public void ThenIAmSuccessfullyAuthenticatedWithABearerToken()
        {
            var response = _stage.User.Recall<RestResponse>("response");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Does.Contain("token"));
        }
    }
}