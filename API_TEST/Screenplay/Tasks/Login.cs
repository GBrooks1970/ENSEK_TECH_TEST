using Screenplay.Actors;
using Screenplay.Utils;

namespace Screenplay.Tasks
{
    public class Login : ITask
    {
        public static Login WithRememberedCredentials() => new Login();

        public void PerformAs(IActor actor)
        {
            var username = actor.Recall<string>("username");
            var password = actor.Recall<string>("password");
            var payload = new { username, password };
            var apiClient = new SafeApiClient("https://qacandidatetest.ensek.io");
            var response = apiClient.CallEndpointAlwaysReturn("/ENSEK/login", RestSharp.Method.Post, payload);
            actor.Remember("response", response);
        }
    }
}