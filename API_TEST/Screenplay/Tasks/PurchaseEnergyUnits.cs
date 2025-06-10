using System;
using RestSharp;
using Screenplay.Actors;
using Screenplay.Utils;

namespace Screenplay.Tasks
{
    public class PurchaseEnergyUnits : ITask
    {
        private readonly string _energyId;
        private readonly string _quantity;

        private PurchaseEnergyUnits(string energyId, string quantity)
        {
            _energyId = energyId;
            _quantity = quantity;
        }

        public static PurchaseEnergyUnits With(string energyId, string quantity)
        {
            return new PurchaseEnergyUnits(energyId, quantity);
        }

        public void PerformAs(IActor actor)
        {
            var apiClient = new SafeApiClient("https://qacandidatetest.ensek.io");
            var endpoint = $"/ENSEK/buy/{_energyId}/{_quantity}";

            // Optionally add authentication header if token is present
            var token = actor.Recall<string>("token");
            System.Action<RestRequest> addHeaders = null;
            if (!string.IsNullOrEmpty(token))
            {
                addHeaders = req => req.AddHeader("Authorization", $"Bearer {token}");
                Console.WriteLine($"Using token: {token}");
            }

            var response = apiClient.CallEndpointAlwaysReturn(endpoint, RestSharp.Method.Put, null, addHeaders);
            actor.Remember("response", response);
        }
    }
}