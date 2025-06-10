using RestSharp;
using System.Net;
using Screenplay.Actors;

namespace Screenplay.Questions
{
    public class ResetConfirmation : IQuestion<bool>
    {
        public static ResetConfirmation Success() => new ResetConfirmation();
        public bool AnsweredBy(IActor actor) => actor.Recall<RestResponse>("response").StatusCode == HttpStatusCode.OK;
    }
}