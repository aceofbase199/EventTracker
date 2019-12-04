using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventTracker.Services.Abstract;
using EventTracker.Views.Dashboard;

namespace EventTracker.Services
{
  public class EventService : IEventService
  {
    public List<Event> GetEvents()
    {
      throw new NotImplementedException();
    }

    public List<Event> GetUserEvents(int userId)
    {
      throw new NotImplementedException();
    }

    public List<Event> GetUserEventsByLocation(int userId, string location)
    {
      throw new NotImplementedException();
    }
  }
}