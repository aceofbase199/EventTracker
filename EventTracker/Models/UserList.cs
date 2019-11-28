using System.Collections.Generic;
using Newtonsoft.Json;

namespace EventTracker.Models
{
  public class UserList
  {
    //[JsonProperty("users")]
    public List<Entities.User> Users { get; set; }
  }
}