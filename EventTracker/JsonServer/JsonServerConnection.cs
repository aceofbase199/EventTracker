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
    private readonly RestClient client;

    public JsonServerConnection()
    {
      client = new RestClient();
    }

    public IRestResponse Connect(string connectionString)
    {
      var request = new RestRequest(connectionString, Method.GET);
      var response = client.Execute(request);

      return response;
    }

    public IRestResponse PostMethod<T>(string connectionString, T body)
    {
      var request = new RestRequest(connectionString, Method.POST) { RequestFormat = DataFormat.Json} ;
      request.AddJsonBody( new
      {
        Users = body,
      });
      //request.Parameters[0].Name = "users";
      var response = client.Execute(request);

      return response;
    }
  }
}