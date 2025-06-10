using OpenQA.Selenium;
using Ensek.UITests.Screenplay;

namespace Ensek.UITests.Screenplay.Tasks
{
    public class OpenBuyEnergyPage : ITask
    {
        public void PerformAs(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://ensekautomationcandidatetest.azurewebsites.net/Energy/Buy");
        }
    }
}
