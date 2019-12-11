using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventTracker.Controllers
{
  [Authorize]
  public class DashboardController : Controller
    {
      public IActionResult Index()
      {
          return View("Dashboard");
      }

      public IActionResult CreateEvent()
      {
        return View("CreateEvent");
      }
  }
}