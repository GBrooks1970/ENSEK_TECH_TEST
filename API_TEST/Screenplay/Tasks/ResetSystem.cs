using System;
using RestSharp;
using Screenplay.Actors;
using Screenplay.Utils;

namespace Screenplay.Tasks
{
    public class ResetSystem : ITask
    {
        public static ResetSystem Execute() => new ResetSystem();

        public void PerformAs(IActor actor)
        {
            var apiClient = new SafeApiClient("https://qacandidatetest.ensek.io");
            var endpoint = "/ENSEK/reset";

            // Optionally add authentication header if token is present
            var token = actor.Recall<string>("token");
            System.Action<RestRequest> addHeaders = null;
            if (!string.IsNullOrEmpty(token))
            {
                addHeaders = req => req.AddHeader("Authorization", $"Bearer {token}");
                Console.WriteLine($"Using token: {token}");
            }

            var response = apiClient.CallEndpointAlwaysReturn(endpoint, RestSharp.Method.Post, null, addHeaders);
            actor.Remember("response", response);
        }
    }
}