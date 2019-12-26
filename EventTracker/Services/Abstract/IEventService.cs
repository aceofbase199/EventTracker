using System.Collections.Generic;
using EventTracker.Models;

namespace EventTracker.Services.Abstract
{
  public interface IEventService
  {
    List<EventDTO> GetEvents();
    List<EventDTO> GetUserEvents(int userId);
    List<EventDTO> GetEventsByLocation(string location);
    List<EventDTO> GetEventsByLocation(List<EventDTO> events, string location);
    List<EventDTO> GetPastEvents();
    List<EventDTO> GetPastEvents(List<EventDTO> events);
    List<EventDTO> GetUpcomingEvents();
    List<EventDTO> GetUpcomingEvents(List<EventDTO> events);
    List<string> GetEventsLocations(List<EventDTO> events);
  }
}