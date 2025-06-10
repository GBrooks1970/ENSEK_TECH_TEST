using OpenQA.Selenium;
using Ensek.UITests.Utilities;

namespace Ensek.UITests.Screenplay.Questions
{
    public class UnitsUpdated_BuyEnergy : IQuestion<bool>
    {
        private readonly string _energyType;

        public UnitsUpdated_BuyEnergy(string energyType)
        {
            _energyType = energyType;
        }

        public bool AnsweredBy(IWebDriver driver)
        {
            var loader = new SelectorLoader();
            loader.LoadFromFile("Env/BuyEnergy_CombinedSelectors.json");
            var selector = loader.GetByEnergyType(_energyType);
            var cell = driver.FindElement(By.CssSelector(selector.Selectors.Css.UnitsAvailable));
            return int.TryParse(cell.Text, out var value) && value >= 0;
        }
    }
}
