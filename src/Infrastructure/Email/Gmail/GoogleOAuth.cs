using Google.Apis.Auth.OAuth2;
using Google.Apis.Util;

namespace Infrastructure.Email.Gmail;

public class GoogleOAuth
{
  private readonly string _clientId;
  private readonly string _secretKey;
  private readonly string[] _scopes;

  public GoogleOAuth()
  {
    _clientId = "1073231400201-l5o8jeoparj7rnoe5gevp57h8g18nprp.apps.googleusercontent.com";
    _secretKey = "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";
    _scopes = new[]
    {
      "https://www.googleapis.com/auth/gmail.send"
    };
    
  }

  public async Task<UserCredential> Authenticate()
  {
    var credentials = await GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
    {
      ClientId = _clientId,
      ClientSecret = _secretKey
    }, _scopes, "user", CancellationToken.None);

    if (credentials.Token.IsExpired(SystemClock.Default))
      await credentials.RefreshTokenAsync(CancellationToken.None);

    return credentials;
  }
}