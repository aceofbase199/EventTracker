using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EventTracker.Models;
using Newtonsoft.Json;
using RestSharp;
using JsonSerializer = RestSharp.Serialization.Json.JsonSerializer;

namespace EventTracker.JsonServer
{
  public class JsonServerConnection : IConnectionStrategy
  {
    public List<User> Connect(string connectionString)
    {
      var client = new RestClient();
      var request = new RestRequest(connectionString, Method.GET);
      var  response = client.Execute<List<User>>(request);

      var users = response.IsSuccessful ? JsonConvert.DeserializeObject<UserList>(response.Content).Users : null;

      return users;
    }
  }
}