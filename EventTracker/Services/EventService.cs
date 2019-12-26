using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventTracker.Entities;
using EventTracker.Models;
using EventTracker.Models.Enums;
using EventTracker.Services.Abstract;
using EventTracker.Utils;

namespace EventTracker.Services
{
  public class EventService : IEventService
  {
    private readonly IMapper _mapper;
    private readonly IConnectionService _connectionService;

    public EventService(IConnectionService connectionService, IMapper mapper)
    {
      _connectionService = connectionService;
      _mapper = mapper;
    }
    public List<EventDTO> GetEvents()
    {
      var response = _connectionService.Get("events");
      var events = DeserializationUtil.DeserializeRestResponse<List<Event>>(response);
      var mappedEvents = _mapper.Map<List<EventDTO>>(events);

      return mappedEvents;
    }

    public List<EventDTO> GetUserEvents(int userId)
    {
      var userEvents = GetEvents().Where(x => x.EventType == EventType.Private).ToList();

      return userEvents;
    }

    public List<string> GetEventsLocations(List<EventDTO> events)
    {
      return events.Select(x => x.Location).Distinct().ToList();
    }

    public List<EventDTO> GetEventsByLocation(List<EventDTO> events, string location)
    {
      return events.Where(x => x.Location == location).ToList();
    }

    public List<EventDTO> GetEventsByLocation(string location)
    {
      return GetEvents().Where(x => x.Location == location).ToList();
    }

    public List<EventDTO> GetPastEvents(List<EventDTO> events)
    {
      var utcNow = DateTime.UtcNow;
      var userEvents = events.Where(x => x.Date <= utcNow).ToList();

      return userEvents;
    }

    public List<EventDTO> GetPastEvents()
    {
      var utcNow = DateTime.UtcNow;
      var userEvents = GetEvents().Where(x => x.Date <= utcNow).ToList();

      return userEvents;
    }

    public List<EventDTO> GetUpcomingEvents(List<EventDTO> events)
    {
      var utcNow = DateTime.UtcNow;
      var nextMonth = utcNow.AddMonths(1);
      var userEvents = events.Where(x => x.Date > utcNow && x.Date <= nextMonth).ToList();

      return userEvents;
    }

    public List<EventDTO> GetUpcomingEvents()
    {
      var utcNow = DateTime.UtcNow;
      var nextMonth = utcNow.AddMonths(1);
      var userEvents = GetEvents().Where(x => x.Date > utcNow && x.Date <= nextMonth).ToList();

      return userEvents;
    }
  }
}