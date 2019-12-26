using System.Diagnostics;
using System.Linq;
using System.Net;
using EventTracker.JsonServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EventTracker.Models;
using EventTracker.Services;
using EventTracker.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;

namespace EventTracker.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    //private readonly IUserService _userService;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Login()
    {
      if (!HttpContext.User.Identity.IsAuthenticated)
      {
        return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
      }

      return RedirectToAction("Index", "Dashboard");
      //return View("LoginPage");
    }

    //[Authorize(Roles = "Everyone")]
    //public IActionResult Everyone()
    //{
    //  return View();
    //}

    public IActionResult Index()
    {
      return View();
    }

    //[HttpPost]
    //public IActionResult Login(UserDTO user)
    //{
    //  if (!ModelState.IsValid)
    //  {
    //    return View("LoginPage");
    //  }

    //  if (!_userService.IsValidUser(user))
    //  {
    //    ModelState.AddModelError("Not_Valid_User", "The user name or password is incorrect");

    //    return View("LoginPage");
    //  }

    //  return View("~/Views/Dashboard/Dashboard.cshtml");
    //}

    public IActionResult Logout()
    {
      return new SignOutResult(new[]
      {
        OpenIdConnectDefaults.AuthenticationScheme,
        CookieAuthenticationDefaults.AuthenticationScheme
      });
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