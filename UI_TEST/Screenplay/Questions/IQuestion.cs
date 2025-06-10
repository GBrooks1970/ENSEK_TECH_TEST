using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Ensek.UITests.Screenplay
{
    public interface IQuestion<T>
    {
        T AnsweredBy(IWebDriver driver);
    }
}

namespace Ensek.UITests.Screenplay.Questions
{
    // An interface for questions that return a tuple of two values
    public interface IQuestion2<T1, T2>
    {
        (T1, T2) AnsweredBy(IWebDriver driver);
    }
}
