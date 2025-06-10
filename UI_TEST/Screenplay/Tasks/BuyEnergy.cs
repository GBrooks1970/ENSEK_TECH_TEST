using OpenQA.Selenium;
using Ensek.UITests.Utilities;

namespace Ensek.UITests.Screenplay.Tasks
{
    public class BuyEnergy : ITask
    {
        private readonly string _energyType;
        private readonly string _quantity;

        public BuyEnergy(string energyType, string quantity)
        {
            _energyType = energyType;
            _quantity = quantity;
        }

        public void PerformAs(IWebDriver driver)
        {
            var loader = new SelectorLoader();
            loader.LoadFromFile("Env/BuyEnergy_CombinedSelectors.json");
            var selector = loader.GetByEnergyType(_energyType);

            var input = driver.FindElement(By.CssSelector(selector.Selectors.Css.Input));
            input.Clear();
            input.SendKeys(_quantity);
            driver.FindElement(By.CssSelector(selector.Selectors.Css.BuyButton)).Click();
        }
    }
}
