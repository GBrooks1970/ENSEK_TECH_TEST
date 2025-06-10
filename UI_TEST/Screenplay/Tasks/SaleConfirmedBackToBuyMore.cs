using OpenQA.Selenium;
using Ensek.UITests.Utilities;

namespace Ensek.UITests.Screenplay.Tasks
{
    public class SaleConfirmedBackToBuyMore : ITask
    {
        private readonly string _energyType= "Electricity"; // Default value, can be overridden

        public SaleConfirmedBackToBuyMore(string energyType = "Electricity")
        {
            _energyType = energyType;
        }

        public void PerformAs(IWebDriver driver)
        {
            var loader = new SelectorLoader();
            loader.LoadFromFile("Env/BuyEnergy_CombinedSelectors.json");
            var selector = loader.GetByEnergyType(_energyType);

            //Click the "Buy More" button on the Sale Confirmed page
            driver.FindElement(By.CssSelector(selector.Selectors.Css.BuyMoreButton)).Click();
        }
    }
}
