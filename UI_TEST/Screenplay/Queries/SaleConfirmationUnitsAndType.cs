using OpenQA.Selenium;
using Ensek.UITests.Screenplay.Questions;
using System.Text.RegularExpressions;
using System;

public class SaleConfirmationUnitsAndType : IQuestion2<int, string>
{
    private readonly string _energyType = "Electricity"; // Default to electricity if not specified

    public SaleConfirmationUnitsAndType(string energyType= "Electricity")
    {
        _energyType = energyType;
    }

    public (int, string) AnsweredBy(IWebDriver driver)
    {
        // Example text: "There are now 2998 units of Gas left in our stores."
        var loader = new SelectorLoader();
        loader.LoadFromFile("Env/BuyEnergy_CombinedSelectors.json");
        var selector = loader.GetByEnergyType(_energyType);
        var cell = driver.FindElement(By.CssSelector(selector.Selectors.Css.SaleConfirmResult));

        var regex = new Regex(@"There are now (\d+) units of (\w+) left in our stores\.");
        var text = cell.Text;
        Console.WriteLine($"Sale Confirmed text: {text}");
        var match = regex.Match(text);

        if (match.Success)
        {
            int units = int.Parse(match.Groups[1].Value);
            string energyType = match.Groups[2].Value;
            return (units, energyType);
        }
        return (-100000, string.Empty); // Indicate failure
    }
}