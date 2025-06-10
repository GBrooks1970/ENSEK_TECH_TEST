using System;
using RestSharp;
using Screenplay.Actors;
using Screenplay.Utils;

namespace Screenplay.Tasks
{
    public class ViewOrders : ITask
    {
        public static ViewOrders Execute() => new ViewOrders();

        public void PerformAs(IActor actor)
        {
            var apiClient = new SafeApiClient("https://qacandidatetest.ensek.io");
            var endpoint = "/ENSEK/orders";

             // Optionally add authentication header if token is present
            var token = actor.Recall<string>("token");
            System.Action<RestRequest> addHeaders = null;
            if (!string.IsNullOrEmpty(token))
            {
                addHeaders = req => req.AddHeader("Authorization", $"Bearer {token}");
                Console.WriteLine($"Using token: {token}");
            }

            var response = apiClient.CallEndpointAlwaysReturn(endpoint, RestSharp.Method.Get, null, addHeaders);
            actor.Remember("response", response);
        }
    }
}