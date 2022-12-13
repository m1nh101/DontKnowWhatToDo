using Azure.Identity;
using Microsoft.Graph;

namespace Infrastructure.Email.Outlook;

public class MicrosoftAuthentication
{
  private readonly string[] _scopes;
  private readonly string _clientId;
  private readonly string _sercretKey;
  private readonly string _tenanId;

  public MicrosoftAuthentication()
  {
    _clientId = "063db0ca-5e1b-46e2-8b7a-be0268724a29";
    _sercretKey = "3c08Q~R1knun-V2dQRtGEJ1U2TSej0Ek~Wzhbaz3";
    _scopes = new string[] { /*"https://graph.microsoft.com/.default"*/ "Mail.Send", "User.Read" };
    _tenanId = "7dceb2f0-55ea-4cdc-8555-98450f3693e6";

  }

  public GraphServiceClient Authenticate()

  {
    var options = new InteractiveBrowserCredentialOptions
    {
      TenantId = _tenanId,
      ClientId = _clientId,
      AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
      RedirectUri = new Uri("http://localhost:1440")
    };

    var credential = new InteractiveBrowserCredential(options);
    return new GraphServiceClient(credential, _scopes);
  }
}