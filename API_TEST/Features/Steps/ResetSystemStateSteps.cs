using System.Net;
using NUnit.Framework;
using RestSharp;
using Screenplay.Actors;
using Screenplay.Tasks;
using Screenplay.Questions;
using TechTalk.SpecFlow;
using System.Linq;

namespace Features.Steps
{
    [Binding]
    public class ResetSystemStateSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Stage _stage;

        public ResetSystemStateSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _stage = _scenarioContext.Get<Stage>("Stage");
        }

        [When(@"I request to reset the system")]
        public void WhenIRequestToResetTheSystem()
        {
            _stage.User.AttemptsTo(ResetSystem.Execute());
        }

        [Then(@"the system is reset successfully")]
        public void ThenTheSystemIsResetSuccessfully()
        {
            Assert.That(_stage.User.AsksFor(ResetConfirmation.Success()), Is.True);
        }
    }
}