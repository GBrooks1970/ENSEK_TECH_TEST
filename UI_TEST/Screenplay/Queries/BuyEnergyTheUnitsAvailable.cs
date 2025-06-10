using OpenQA.Selenium;
using Ensek.UITests.Utilities;
using System;


namespace Ensek.UITests.Screenplay.Tasks
{
    public class BuyEnergyTheUnitsAvailable : IQuestion<int>
    {
        private readonly string _energyType;

        public BuyEnergyTheUnitsAvailable(string energyType)
        {
            _energyType = energyType;
        }

        public int AnsweredBy(IWebDriver driver)
        {
            var loader = new SelectorLoader();
            loader.LoadFromFile("Env/BuyEnergy_CombinedSelectors.json");
            var selector = loader.GetByEnergyType(_energyType);
            var cell = driver.FindElement(By.CssSelector(selector.Selectors.Css.UnitsAvailable));
            var text = cell.Text;
            Console.WriteLine($"Quanity of Units Available: {text}");
            var UnitsAvailable = int.Parse(text);
            Console.WriteLine($"Units available for {_energyType}: {UnitsAvailable}");
            return UnitsAvailable;
        }
    }

    

}
