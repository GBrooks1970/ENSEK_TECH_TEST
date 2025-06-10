using OpenQA.Selenium;

namespace Ensek.UITests.Screenplay.Questions
{
    public class ErrorMessageDisplayed : IQuestion<bool>
    {
        public bool AnsweredBy(IWebDriver driver)
        {
            // Check if the page source contains the word "error" or if there are any elements with the class "error"
            // This is a simple check; it needs to refined it based on better application error handling
            return driver.PageSource.Contains("error") || driver.FindElements(By.ClassName("error")).Count > 0;
        }
    }
}
