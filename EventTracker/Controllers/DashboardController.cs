using EventTracker.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace EventTracker.Controllers
{
  [Authorize]
  public class DashboardController : Controller
  {
    private readonly IEventService _eventService;

    public DashboardController(IEventService eventService)
    {
      _eventService = eventService;
    }
    public IActionResult Index()
    {
      var events = _eventService.GetEvents();
      var locations = _eventService.GetEventsLocations(events);
      
      ViewBag.PastEvents = _eventService.GetPastEvents(events);
      ViewBag.UpcomingEvents = _eventService.GetUpcomingEvents(events);
      ViewBag.Locations = locations.Select(x => new SelectListItem { Value = x, Text = x });
      ViewBag.SuggestedEvents = _eventService.GetEventsByLocation(events, locations.FirstOrDefault());
      ViewData["SuggestedEvents"] = ViewBag.SuggestedEvents;

      return View("Dashboard");
    }

    public IActionResult CreateEvent()
    {
      return View("CreateEvent");
    }
  }
}