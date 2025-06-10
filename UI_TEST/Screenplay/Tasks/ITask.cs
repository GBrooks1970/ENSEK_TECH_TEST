using OpenQA.Selenium;

namespace Ensek.UITests.Screenplay
{
    public interface ITask
    {
        void PerformAs(IWebDriver driver);
    }
}
