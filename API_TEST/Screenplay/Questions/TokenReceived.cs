using Screenplay;
using Screenplay.Actors;
using Screenplay.Tasks;
using Screenplay.Questions;
using System.Net;
using RestSharp;

public class TokenReceived : IQuestion<bool>
{
    public static TokenReceived FromResponse() => new TokenReceived();
    public static TokenReceived Unauthorized() => new TokenReceived(false);
    private readonly bool expectSuccess;
    public TokenReceived(bool expectSuccess = true) => this.expectSuccess = expectSuccess;

    public bool AnsweredBy(IActor actor)
    {
        var response = actor.Recall<RestResponse>("response");
        return expectSuccess ? response.StatusCode == HttpStatusCode.OK && response.Content.Contains("token") : response.StatusCode == HttpStatusCode.Unauthorized;
    }
}
