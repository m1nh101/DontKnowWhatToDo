// See https://aka.ms/new-console-template for more information
using Infrastructure.Email;
using Infrastructure.Email.Outlook;

Console.WriteLine("Running");

MicrosoftAuthentication outlook = new MicrosoftAuthentication();

//var token = await outlook.GetUserAccessToken();

//Console.WriteLine($"User token = {token}");


//await client.SendMail("Test gui mail lan 2", "Test gui mail thoi", "minhdd148@gmail.com");