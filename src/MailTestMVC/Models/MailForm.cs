using Infrastructure.Email.Outlook;

namespace MailTestMVC.Models
{
  public class MailForm
  {
    public string CC { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public IFormFileCollection Attachments { get; set; } = null!;

    public async Task<MailItem[]> ToMailItem()
    {
      var sources = new List<MailItem>();

      if(Attachments != null)
      {
        foreach (var file in Attachments)
        {
          using var stream = new MemoryStream();

          await file.CopyToAsync(stream);

          var item = new MailItem(file.FileName, file.ContentType, stream.ToArray());

          sources.Add(item);
        }
      }

      return sources.ToArray();
    }
  }
}
