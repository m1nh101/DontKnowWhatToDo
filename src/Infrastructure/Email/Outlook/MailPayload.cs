using Microsoft.Graph;

namespace Infrastructure.Email.Outlook;

public class MailItem
{
  public MailItem(string name, string contentType, byte[] content)
  {
    Name = name;
    Content = content;
    ContentType = contentType;
  }

  public string Name { get; set; }
  public string ContentType { get; set; }
  public byte[] Content { get; set; }
  public string ContentId => Guid.NewGuid().ToString();
}

public class MailPayload
{
  private IEnumerable<string> _recipients = new List<string>();
  private IEnumerable<string> _ccRecipients = new List<string>();
  private IEnumerable<string> _bccRecipients = new List<string>();
  private IList<MailItem> _attachments = new List<MailItem>();

  public MailPayload(string subject, string content)
  {
    Content = content;
    Subject = subject;
  }

  public MailPayload WithRecipients(params string[] recipients)
  {
    _recipients = recipients.ToArray();
    return this;
  }

  public MailPayload WithCCRecipients(params string[] ccRecipients)
  {
    _ccRecipients = ccRecipients.ToArray();
    return this;
  }

  public MailPayload WithAttachments(params MailItem[] attachments)
  {
    _attachments = attachments.ToArray();
    return this;
  }

  public MailPayload WithBCCRecipients(params string[] bccRecipients)
  {
    _bccRecipients = bccRecipients.ToArray();
    return this;
  }

  public string Content { get; init; }
  public string Subject { get; init; }
  public bool HasAttachment => _attachments.Any();
  public IEnumerable<Recipient> Recipients => ToReceipientsAddress(_recipients);
  public IEnumerable<Recipient> CCRecipients => ToReceipientsAddress(_ccRecipients);
  public IEnumerable<Recipient> BCCRecipients => ToReceipientsAddress(_bccRecipients);

  public MessageAttachmentsCollectionPage GetAttachmentFiles()
  {
    MessageAttachmentsCollectionPage attachments = new();

    foreach (var file in _attachments)
    {
      attachments.Add(new FileAttachment
      {
        ContentType = file.ContentType,
        Name = file.Name,
        ContentId = file.ContentId,
        ContentBytes = file.Content
      });
    }

    return attachments;
  }

  private static IEnumerable<Recipient> ToReceipientsAddress(IEnumerable<string> receipients)
  {
    return receipients.Select(e => new Recipient { EmailAddress = new EmailAddress { Address = e } });
  }
}