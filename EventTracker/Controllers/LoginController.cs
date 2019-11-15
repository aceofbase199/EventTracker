using System.Diagnostics;
using System.Linq;
using EventTracker.JsonServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EventTracker.Models;

namespace EventTracker.Controllers
{
  public class LoginController : Controller
  {
    private const string JsonServerConnectionString = "https://my-json-server.typicode.com/aceofbase199/demo/db";
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
      _logger = logger;
    }

    public IActionResult Login()
    {
      return View("LoginPage");
    }

    [HttpPost]
    public IActionResult Login(User user)
    {
      if (!ModelState.IsValid)
      {
        return View("LoginPage");
      }

      if (!ValidateUser(user))
      {
        ModelState.AddModelError("Not_Valid_User", "The user name or password is incorrect");
        
        return View("LoginPage");
      }

      return View("~/Views/Dashboard/Dashboard.cshtml", user);
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

    private bool ValidateUser(User user)
    {
      var context = new ConnectionContext(new JsonServerConnection(), JsonServerConnectionString);
      var users = context.Connect();
      var existingUser = users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);

      return existingUser != null;
    }
  }
}