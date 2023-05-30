using AspnetNetCoreMVCApp.Models;
using AspnetNetCoreMVCApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspnetNetCoreMVCApp.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
   
    private readonly EmailService emailService;

    // MyDb db = new MyDb();

    // Service hizmetlerinin instancelarını Ioc üretir. DIP ile servis bağımlılıkları ortadan kalkar.
    public HomeController(ILogger<HomeController> logger, EmailService emailService) // MyDb db
    {
      _logger = logger;
      this.emailService = emailService;
      // db =db;
    }

    public IActionResult Index()
    {
      this.emailService.Send();

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}