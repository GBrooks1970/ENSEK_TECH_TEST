using System;
using RestSharp;
using Screenplay.Actors;
using Screenplay.Utils;

namespace Screenplay.Tasks
{
    public class DeleteOrder : ITask
    {
        private readonly string _id;
        private DeleteOrder(string id) => _id = id;
        public static DeleteOrder WithRememberedId() => new DeleteOrder("abc123");

        public void PerformAs(IActor actor)
        {
            var apiClient = new SafeApiClient("https://qacandidatetest.ensek.io");
            var endpoint = $"/ENSEK/orders/{_id}";

            // Optionally add authentication header if token is present
            var token = actor.Recall<string>("token");
            System.Action<RestRequest> addHeaders = null;
            if (!string.IsNullOrEmpty(token))
            {
                addHeaders = req => req.AddHeader("Authorization", $"Bearer {token}");
                Console.WriteLine($"Using token: {token}");
            }

            var response = apiClient.CallEndpointAlwaysReturn(endpoint, RestSharp.Method.Delete, null, addHeaders);

            actor.Remember("response", response);
        }
    }
}