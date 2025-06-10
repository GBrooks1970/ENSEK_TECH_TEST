using System;
using System.Collections.Generic;
using Ensek.UITests.Utilities;
using OpenQA.Selenium;
using Screenplay.Actors;
using Ensek.UITests.Screenplay.Questions;

namespace Ensek.UITests.Screenplay.Actors
{
    public interface IActor
    {
        void AttemptsTo(ITask task);
        T AsksFor<T>(IQuestion<T> question);
        (T1, T2) AsksFor<T1, T2>(IQuestion2<T1, T2> question);
    }

    public class User : IActor
    {
        private readonly IWebDriver _driver;

        public User()
        {
            _driver = DriverFactory.Driver;
        }

        private readonly Dictionary<string, object> _memory = new Dictionary<string, object>();

        // Store a value in memory
        public void Remember<T>(string key, T value)
        {
            _memory[key] = value;
        }

        // Retrieve a value from memory
        public T Recall<T>(string key)
        {
            if (_memory.TryGetValue(key, out var value) && value is T typedValue)
            {
                return typedValue;
            }
            return default;
        }

        public void AttemptsTo(ITask task)
        {
            task.PerformAs(_driver);
        }

        public T AsksFor<T>(IQuestion<T> question)
        {
            return question.AnsweredBy(_driver);
        }

        public (T1, T2) AsksFor<T1, T2>(IQuestion2<T1, T2> question)
        {
            return question.AnsweredBy(_driver);
        }
    }
}
