
using TechTalk.SpecFlow;
using Ensek.UITests.Utilities;

namespace Ensek.UITests.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = DriverFactory.Driver; // Ensures WebDriver is initialized
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverFactory.Quit(); // Cleanup after each scenario
        }
    }
}
