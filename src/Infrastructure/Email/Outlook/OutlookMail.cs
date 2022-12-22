using Microsoft.Graph;

namespace Infrastructure.Email.Outlook;

public class OutlookMail
{
  private readonly GraphServiceClient _client;

  public OutlookMail(GraphServiceClient client)
  {
    _client = client;
  }

  public async Task SendMail(MailPayload payload)
  {
    var message = new Message()
    {
      Subject = payload.Subject,
      Body = new ItemBody
      {
        ContentType = BodyType.Text,
        Content = payload.Content
      },
      ToRecipients = payload.Recipients,
      BccRecipients = payload.BCCRecipients,
      CcRecipients = payload.CCRecipients
    };

    await _client.Me.SendMail(message, false).Request().PostAsync();

    Console.WriteLine("Mail sent to: ");
  }

  public async Task<bool> MakeDraft(MailPayload payload)
  {
    var attachments = payload.GetAttachmentFiles();

    var message = new Message()
    {
      Subject = payload.Subject,
      Body = new ItemBody
      {
        ContentType = BodyType.Text,
        Content = payload.Content
      },
      ToRecipients = payload.Recipients,
      BccRecipients = payload.BCCRecipients,
      CcRecipients = payload.CCRecipients,
      HasAttachments = attachments.Any(),
      Attachments = attachments
    };

    await _client.Me.Messages.Request().AddAsync(message);

    return true;
  }
}