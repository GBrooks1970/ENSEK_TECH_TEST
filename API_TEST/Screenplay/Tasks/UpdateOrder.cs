using System;
using RestSharp;
using Screenplay.Actors;
using Screenplay.Utils;

namespace Screenplay.Tasks
{
    public class UpdateOrder : ITask
    {
        private readonly string _id;
        private readonly object _updatePayload;

        private UpdateOrder(string id, object updatePayload)
        {
            _id = id;
            _updatePayload = updatePayload;
        }

        // For demo, use a static payload and id. In real tests, retrieve from memory or parameters.
        public static UpdateOrder WithRememberedId()
        {
            var orderId = "abc123"; // Replace with dynamic retrieval if needed
            var payload = new { status = "updated" }; // Example payload
            return new UpdateOrder(orderId, payload);
        }

        internal static ITask With(string orderId, object payload)
        {
            return new UpdateOrder(orderId, payload);
        }

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

            var response = apiClient.CallEndpointAlwaysReturn(endpoint, RestSharp.Method.Put, _updatePayload, addHeaders);
            actor.Remember("response", response);
        }
    }
}