using System.Net.Mail;

namespace Infrastructure.Email.Gmail;

public class MailPayload
{
  public string To { get; set; } = string.Empty;
  public string Subject { get; set; } = string.Empty;
  public IList<string> CC { get; set; } = new List<string>();
  public IList<string> BCC { get; set; } = new List<string>();
  public string Body { get; set; } = string.Empty;
  public AttachmentCollection Attachments { get; set; } = null!;
}