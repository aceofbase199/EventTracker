using System;
using EventTracker.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventTracker.Views.Dashboard
{
  public class Event : PageModel
  {
    public string EventName { get; set; }

    public string Organizer { get; set; }

    public Location Location { get; set; }

    public DateTime DateTime { get; set; }
  }
}