using System.Diagnostics;
using System.Linq;
using EventTracker.JsonServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EventTracker.Models;
using EventTracker.Services;
using EventTracker.Services.Abstract;

namespace EventTracker.Controllers
{
  public class LoginController : Controller
  {
    private const string JsonServerConnectionString = "https://my-json-server.typicode.com/aceofbase199/demo/db";
    private readonly ILogger<LoginController> _logger;
    private readonly IUserService _userService;

    public LoginController(ILogger<LoginController> logger, IUserService userService)
    {
      _logger = logger;
      _userService = userService;
    }

    public IActionResult Login()
    {
      return View("LoginPage");
    }

    [HttpPost]
    public IActionResult Login(UserDTO user)
    {
      if (!ModelState.IsValid)
      {
        return View("LoginPage");
      }

      if (!_userService.IsValidUser(user))
      {
        ModelState.AddModelError("Not_Valid_User", "The user name or password is incorrect");
        var users = _userService.SaveUser(user);

        return View("LoginPage");
      }

      return View("~/Views/Dashboard/Dashboard.cshtml");
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