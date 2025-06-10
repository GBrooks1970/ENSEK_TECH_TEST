using Ensek.UITests.Screenplay;

namespace Screenplay.Actors
{
    public interface IActor
    {
        T AsksFor<T>(IQuestion<T> question);
        void AttemptsTo(ITask task);
        T Recall<T>(string key);
        void Remember<T>(string key, T value);
    }
}
