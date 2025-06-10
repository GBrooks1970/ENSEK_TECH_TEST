using Screenplay.Actors;

namespace Screenplay.Tasks
{
    public interface ITask
    {
        void PerformAs(IActor actor);
    }
}