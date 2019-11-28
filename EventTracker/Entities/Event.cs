using Newtonsoft.Json;
using System;
using EventTracker.Models.Enums;

namespace EventTracker.Entities
{
  public class Event
  {
    public int Id { get; set; }
    public string EventName { get; set; }

    public string Organizer { get; set; }

    public string Location { get; set; }

    [JsonProperty("evtTp")]
    public EventType EventType { get; set; }

    public DateTime DateTime { get; set; }
  }
}