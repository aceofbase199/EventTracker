using System;
using EventTracker.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EventTracker.Views.Dashboard
{
  public class Event : PageModel
  {
    public string EventName { get; set; }

    public string Organizer { get; set; }

    public string Location { get; set; }

    [JsonProperty("evtTp")]
    public EventType EventType { get; set; }

    public DateTime DateTime { get; set; }
  }
}