using System.Net;
using RestSharp;
using Screenplay.Actors;

namespace Screenplay.Questions
{
    public class OrderHistoryReturned : IQuestion<bool>
    {
        public static OrderHistoryReturned Exists() => new OrderHistoryReturned(HttpStatusCode.OK);
        public static OrderHistoryReturned Deleted() => new OrderHistoryReturned(HttpStatusCode.OK);
        public static OrderHistoryReturned Updated() => new OrderHistoryReturned(HttpStatusCode.OK);
        public static OrderHistoryReturned ContainsOrder() => new OrderHistoryReturned(HttpStatusCode.OK);
        public static OrderHistoryReturned BadRequest() => new OrderHistoryReturned(HttpStatusCode.BadRequest);

        private readonly HttpStatusCode _status;
        public OrderHistoryReturned(HttpStatusCode status) => _status = status;

        public bool AnsweredBy(IActor actor)
        {
            var response = actor.Recall<RestResponse>("response");
            return response != null && response.StatusCode == _status;
        }
    }
}