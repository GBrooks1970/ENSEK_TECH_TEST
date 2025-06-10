using System.Collections.Generic;
using Screenplay.Questions;
using Screenplay.Tasks;

namespace Screenplay.Actors
{
    public class Stage
    {
        public Stage(User user)
        {
            User = user;
        }

        public IActor User { get; set; } = new User("API Tester");
    }

    public class User : IActor
    {
        public string Name { get; }

        public User(string name)
        {
            Name = name;
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
           task.PerformAs(this);
        }

        public object AsksFor(IQuestion<bool> question)
        {
            return question.AnsweredBy(this);
        }

        // ...other User methods...
    }
}