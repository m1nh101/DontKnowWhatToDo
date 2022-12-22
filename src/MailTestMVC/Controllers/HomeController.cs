using Infrastructure.Email.Outlook;
using MailTestMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MailTestMVC.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly OutlookMail _mailClient;

    public HomeController(ILogger<HomeController> logger,
      OutlookMail mailClient)
    {
      _logger = logger;
      _mailClient = mailClient;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> SendMail([FromForm] MailForm request)
    {
      var mailItems = await request.ToMailItem();

      MailPayload payload = new MailPayload(request.Subject, request.Body)
          .WithCCRecipients(request.CC)
          .WithAttachments(mailItems);

      await _mailClient.MakeDraft(payload);

      return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}