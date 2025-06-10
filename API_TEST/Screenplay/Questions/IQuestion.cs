using Screenplay.Actors;

namespace Screenplay.Questions
{
    public interface IQuestion<T>
    {
        T AnsweredBy(IActor actor);
    }
}