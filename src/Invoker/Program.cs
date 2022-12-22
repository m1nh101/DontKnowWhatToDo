// See https://aka.ms/new-console-template for more information

using Infrastructure.Email.Outlook;

Console.WriteLine("Running...");

MicrosoftAuthentication provider = new();

OutlookMail mailClient = new(provider);

MailPayload payload = new MailPayload("Test gui mail", "Test gui mail")
  .WithRecipients("minhdd148@gmail.com");

await mailClient.SendMail(payload);

Console.WriteLine("End Process");