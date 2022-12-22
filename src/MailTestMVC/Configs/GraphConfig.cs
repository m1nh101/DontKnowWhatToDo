using Azure.Identity;
using Microsoft.Graph;

namespace MailTestMVC.Configs;

public static class GraphConfig
{
  public static IServiceCollection ConfigGraph(this IServiceCollection services)
  {
    var clientId = "063db0ca-5e1b-46e2-8b7a-be0268724a29";
    //var sercretKey = "3c08Q~R1knun-V2dQRtGEJ1U2TSej0Ek~Wzhbaz3";
    var scopes = new string[] { "Mail.Send", "User.Read", "Mail.ReadWrite" };
    var tenantId = "common";

    var options = new InteractiveBrowserCredentialOptions
    {
      TenantId = tenantId,
      ClientId = clientId,
      AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
      RedirectUri = new Uri("http://localhost:1440")
    };

    var credential = new InteractiveBrowserCredential(options);

    services.AddSingleton<GraphServiceClient>(sp =>
    {
      return new GraphServiceClient(credential, scopes);
    });

    return services;
  }
}