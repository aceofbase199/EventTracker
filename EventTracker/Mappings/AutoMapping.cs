using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventTracker.Entities;
using EventTracker.Models;
using AutoMapper;

namespace EventTracker.Mappings
{
  public class AutoMapping: Profile
  {
    public AutoMapping()
    {
      CreateMap<Event, EventDTO>().ReverseMap();
    }
  }
}