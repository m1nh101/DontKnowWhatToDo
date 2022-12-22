
// See https://aka.ms/new-console-template for more information
using Outlook = Microsoft.Office.Interop.Outlook;

Console.WriteLine("Start");

Outlook.Application application = new();

Outlook.MailItem oMsg = (Outlook.MailItem)application.CreateItem(Outlook.OlItemType.olMailItem);

oMsg.Subject = "test create draft 2";
oMsg.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
oMsg.BCC = "";
oMsg.To = "empty@test.com";

oMsg.HTMLBody = "<h1 style=\"color: red \">test thoi </h1>";
oMsg.Attachments.Add(@"C:\\Users\Admin\Downloads\note (1).txt", Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);

oMsg.Save();

oMsg = null;
application = null;

Console.WriteLine("Done");