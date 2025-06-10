using RestSharp;
using System;

namespace Screenplay.Utils
{
    public class SafeApiClient
    {
        private readonly RestClient _client;

        public SafeApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public RestResponse CallEndpointAlwaysReturn(string endpoint, Method method = Method.Get, object body = null, Action<RestRequest> configureRequest = null)
        {
            RestResponse response = null;

            try
            {
                var request = new RestRequest(endpoint, method);
                if (body != null)
                    request.AddJsonBody(body);

                configureRequest?.Invoke(request);

                response = _client.Execute(request);

                if (!response.IsSuccessful)
                {
                    Console.WriteLine($"API call returned non-success status: {(int)response.StatusCode} {response.StatusDescription}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }

            return response;
        }
    }
}