using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace Ensek.UITests.Screenplay.Questions
{
    public class PurchaseConfirmationMessageDisplayed : IQuestion<bool>
    {
        private readonly string _energyType;
        private readonly string _quantity;

        public PurchaseConfirmationMessageDisplayed(string energyType, string quantity)
        {
             _energyType = energyType;
            _quantity = quantity;
        }

        public bool AnsweredBy(IWebDriver driver)
        {
            try
            {
                var loader = new SelectorLoader();
                loader.LoadFromFile("Env/BuyEnergy_CombinedSelectors.json");
                var selector = loader.GetByEnergyType(_energyType);
                var confirmation = driver.FindElement(By.CssSelector(selector.Selectors.Css.SaleConfirm));

                // Check if the cell contains a valid number or a confirmation message
                if (confirmation == null || string.IsNullOrWhiteSpace(confirmation.Text))
                    return false;

                // Example text: "Thank you for your purchase of 0 units of Gas We have popped it in the post and it will be with you shortly."
                var regex = new Regex(@"Thank you for your purchase of (\d+) units of (\w+) We have popped it in the post and it will be with you shortly\.");
                var text = confirmation.Text;
                Console.WriteLine($"Purchase Confirmed text: {text}");
                var match = regex.Match(confirmation.Text);
                if (match.Success)
                {
                    int units = int.Parse(match.Groups[1].Value);
                    string energyType = match.Groups[2].Value;
                    return units == int.Parse(_quantity) && energyType.Equals(_energyType, System.StringComparison.OrdinalIgnoreCase);
                }

                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}