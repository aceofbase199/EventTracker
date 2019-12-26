using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventTracker.Models.Enums;

namespace EventTracker.Models
{
  public class EventDTO
  {
    public int Id { get; set; }
    public string EventName { get; set; }
    public string Organizer { get; set; }
    public string Location { get; set; }
    public EventType EventType { get; set; }
    public DateTime Date { get; set; }
  }
}