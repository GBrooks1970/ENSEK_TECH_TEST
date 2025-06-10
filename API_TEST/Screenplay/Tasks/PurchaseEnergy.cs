using System;
using RestSharp;
using Screenplay.Actors;
using Screenplay.Utils;

namespace Screenplay.Tasks
{
    public class PurchaseEnergy : ITask
    {
        private readonly object _id;
        private readonly int _qty;
        private readonly bool _isRaw;
        private readonly string _orderId;

        private PurchaseEnergy(object id, int qty, bool isRaw = false, string orderId = null)
        {
            _id = id; _qty = qty; _isRaw = isRaw; _orderId = orderId;
        }

        public static PurchaseEnergy With(int energyId, int quantity) => new PurchaseEnergy(energyId, quantity);
        public static PurchaseEnergy WithRaw(string id, int quantity) => new PurchaseEnergy(id, quantity, true);
        public static PurchaseEnergy Update(string orderId) => new PurchaseEnergy(1, 15, false, orderId);

        public void PerformAs(IActor actor)
        {
            var apiClient = new SafeApiClient("https://qacandidatetest.ensek.io");


             // Optionally add authentication header if token is present
            var token = actor.Recall<string>("token");
            System.Action<RestRequest> addHeaders = null;
            if (!string.IsNullOrEmpty(token))
            {
                addHeaders = req => req.AddHeader("Authorization", $"Bearer {token}");
                Console.WriteLine($"Using token: {token}");
            }

            if (_orderId == null)
            {
                // Buy energy units
                var endpoint = $"/ENSEK/buy/{_id}/{_qty}";
                var response = apiClient.CallEndpointAlwaysReturn(endpoint, RestSharp.Method.Put, null, addHeaders);
                actor.Remember("response", response);
            }
            else
            {
                // Update order
                var endpoint = $"/ENSEK/orders/{_orderId}";
                var payload = new { energy_id = 1, quantity = 15 };
                var response = apiClient.CallEndpointAlwaysReturn(endpoint, RestSharp.Method.Put, payload, addHeaders);
                actor.Remember("response", response);
            }
        }
    }
}