using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTracker.Entities
{
  public class User
  {
    [JsonProperty("id")]
    public int UserId { get; set; }

    [JsonProperty("userName")]
    public string UserName { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }
  }
}