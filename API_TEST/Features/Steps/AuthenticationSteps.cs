using System;
using System.Net;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using Screenplay.Actors;
using Screenplay.Tasks;
using TechTalk.SpecFlow;

namespace Features.Steps
{
    [Binding]
    public class AuthenticationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Stage _stage;

        public AuthenticationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _stage = _scenarioContext.ContainsKey("Stage")
                ? _scenarioContext.Get<Stage>("Stage")
                : new Stage(new User("API Tester"));
            _scenarioContext.Set(_stage, "Stage");
        }

        [Given(@"I am authenticated")]
        public void GivenIAmAuthenticated()
        {
            _stage.User.Remember("username", "test");
            _stage.User.Remember("password", "testing");
            _stage.User.AttemptsTo(Login.WithRememberedCredentials());
            var response = _stage.User.Recall<RestResponse>("response");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Does.Contain("access_token").And.Contain("message").IgnoreCase);

            // Parse response.Content to JSON and retrieve access_token
            var json = JObject.Parse(response.Content);
            var accessToken = json["access_token"]?.ToString();

            _stage.User.Remember("token", accessToken);
            Console.WriteLine($"token: {accessToken}");
        }
    }
}