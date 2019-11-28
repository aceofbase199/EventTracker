using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace EventTracker.Models
{
  public class UserDTO
  {
    [JsonProperty("id")]
    public int UserId { get; set; }

    [JsonProperty("userName")]
    [Required(ErrorMessage = "UserName is required")]
    public string UserName { get; set; }

    [JsonProperty("password")]
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

  }
}