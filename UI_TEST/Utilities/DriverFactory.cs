using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Ensek.UITests.Utilities
{
    public static class DriverFactory
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver();
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                }
                return _driver;
            }
        }

        public static void Quit()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}
