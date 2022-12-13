using Google.Apis.Gmail.v1.Data;
using Google.Apis.Gmail.v1;
using MimeKit;
using System.Net.Mail;
using System.Text;
using Google.Apis.Services;

namespace Infrastructure.Email.Gmail;

public class MailClient
{
  private readonly GoogleOAuth _auth;
  private const string _from = "minh.xcode@gmail.com";
  private const string _userId = "me";

	public MailClient()
	{
		_auth = new GoogleOAuth();
	}

	public async Task SendMail(MailPayload payload)
	{
    var mailClient = await GetClient();

    var mailMessage = new MailMessage()
    {
      From = new MailAddress(_from),
      Subject = payload.Subject,
      Body = payload.Body,
      IsBodyHtml = false,
    };

    mailMessage.To.Add(new MailAddress(payload.To));
    var mimeMessage = MimeMessage.CreateFromMailMessage(mailMessage);
    var plainText = Encoding.UTF8.GetBytes(mimeMessage.ToString());
    var messageEncoded = Convert.ToBase64String(plainText);

    var message = new Message()
    {
      Raw = messageEncoded
    };

    var mailRequest = mailClient.Users.Messages.Send(message, _userId);
    mailRequest.Execute();

    Console.WriteLine("Email Sent");
  }

  private async Task<GmailService> GetClient()
  {
    var credentital = await _auth.Authenticate();

    return new GmailService(new BaseClientService.Initializer
    {
      HttpClientInitializer = credentital
    });
  }
}