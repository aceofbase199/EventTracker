using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventTracker.Views.Dashboard;

namespace EventTracker.Services.Abstract
{
  public interface IEventService
  {
    List<Event> GetEvents();
    List<Event> GetUserEvents(int userId);
  }
}