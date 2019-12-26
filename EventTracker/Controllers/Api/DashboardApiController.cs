using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using EventTracker.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace EventTracker.Controllers.Api
{
  [Route("api/[controller]")]
  [Authorize]
  public class DashboardApiController : ApiController
  {
    private readonly IEventService _eventService;

    public DashboardApiController(IEventService eventService)
    {
      _eventService = eventService;
    }

    [System.Web.Http.HttpGet]
    public IHttpActionResult GetEventsByLocation(string location)
    {
      var events = _eventService.GetEventsByLocation(location);

      return Ok(events);
    }
  }
}