using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EventTracker.Models;
using Newtonsoft.Json;
using RestSharp;
using JsonSerializer = RestSharp.Serialization.Json.JsonSerializer;

namespace EventTracker.JsonServer
{
  public class JsonServerApi : IJsonServerApi//IConnectionStrategy
  {
    private readonly RestClient client;

    public JsonServerApi()
    {
      client = new RestClient();
    }

    //public IRestResponse Connect(string connectionString)
    //{
    //  var request = new RestRequest(connectionString, Method.GET);
    //  var response = client.Execute(request);

    //  return response;
    //}

    public IRestResponse GetMethod(string connectionString)
    {
      var request = new RestRequest(connectionString);
      var response = client.Execute(request);

      return response;
    }

    public IRestResponse PostMethod<T>(string connectionString, T body)
    {
      var request = new RestRequest(connectionString, Method.POST) { RequestFormat = DataFormat.Json} ;
      request.AddJsonBody(body);
      var response = client.Execute(request);

      return response;
    }
  }
}