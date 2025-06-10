using TechTalk.SpecFlow;
using Screenplay;
using Screenplay.Actors;

[Binding]
public class TestHooks
{
    private readonly ScenarioContext _scenarioContext;

    public TestHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        var stage = new Stage(new User("API Tester"));
        _scenarioContext.Set(stage, "Stage");
    }
}
