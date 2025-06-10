using OpenQA.Selenium;
using Ensek.UITests.Utilities;
using System.Text.RegularExpressions;
using System;

namespace Ensek.UITests.Screenplay.Questions
{
    public class SaleConfirmedUnitsUpdated : IQuestion<bool>
    {
        private readonly string _energyType;

        public SaleConfirmedUnitsUpdated(string energyType)
        {
            _energyType = energyType;
        }

        public bool AnsweredBy(IWebDriver driver)
        {
            var loader = new SelectorLoader();
            loader.LoadFromFile("Env/BuyEnergy_CombinedSelectors.json");
            var selector = loader.GetByEnergyType(_energyType);
            var cell = driver.FindElement(By.CssSelector(selector.Selectors.Css.SaleConfirmResult));
            // Example text: "There are now 2998 units of Gas left in our stores."
            var regex = new Regex(@"There are now (\d+) units of (\w+) left in our stores\.");
            var text = cell.Text;
            Console.WriteLine($"Sale Confirmed text: {text}");
            var match = regex.Match(text);
            // Check if the regex matched and extract the units and energy type
            // Need to refactor this to assert units remaining are as expected
            if (match.Success)
            {
                int units = int.Parse(match.Groups[1].Value);
                string energyType = match.Groups[2].Value;
                return units >= 0 && energyType.Equals(_energyType, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}
