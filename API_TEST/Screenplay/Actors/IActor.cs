using Screenplay.Questions;
using Screenplay.Tasks;

namespace Screenplay.Actors
{
    public interface IActor
    {
        object AsksFor(IQuestion<bool> question);
        void AttemptsTo(ITask task);
        T Recall<T>(string key);
        void Remember<T>(string key, T value);
    }
}
