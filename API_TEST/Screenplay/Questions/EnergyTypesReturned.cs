using Screenplay; 
using Screenplay.Questions; 
using RestSharp;
using System.Net;
using Screenplay.Actors;

namespace Screenplay.Questions
{
    public class EnergyTypesReturned : IQuestion<bool>
    {
        public static EnergyTypesReturned FromResponse() => new EnergyTypesReturned();

        public bool AnsweredBy(IActor User)
        {
            var response = User.Recall<RestResponse>("response");
            return response != null && response.StatusCode == HttpStatusCode.OK;
        }
    }
}