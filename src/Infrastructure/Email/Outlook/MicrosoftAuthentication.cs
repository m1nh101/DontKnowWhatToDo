using Azure.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;

namespace Infrastructure.Email.Outlook;

public class MicrosoftAuthentication
{
  private readonly string[] _scopes;
  private readonly string _clientId;
  private readonly string _sercretKey;
  private readonly string _tenanId;
  private static GraphServiceClient? _client;

  public MicrosoftAuthentication()
  {
    _clientId = "063db0ca-5e1b-46e2-8b7a-be0268724a29";
    _sercretKey = "3c08Q~R1knun-V2dQRtGEJ1U2TSej0Ek~Wzhbaz3";
    _scopes = new string[] { "Mail.Send", "User.Read", "Mail.ReadWrite" };
    _tenanId = "common";
  }

  /// <summary>
  /// 
  /// </summary>
  /// <returns>graph client</returns>
  public GraphServiceClient Authenticate()
  {
    if (_client == null)
    {
      var options = new InteractiveBrowserCredentialOptions
      {
        TenantId = _tenanId,
        ClientId = _clientId,
        AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
        RedirectUri = new Uri("http://localhost:1440")
      };

      var credential = new InteractiveBrowserCredential(options);

      _client = new GraphServiceClient(credential, _scopes);
    }

    return _client;
  }
}

public static class MicrosoftGraph
{
  public static IServiceCollection AddMicrosoftGraphClient(this IServiceCollection services)
  {


    return services;
  }
}